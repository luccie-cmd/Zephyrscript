%include "./src/include/gcc.inc"

section .text

global Write
Write:
    call puts
    ret

global WriteLine
WriteLine:
    push rbp
    mov rbp, rsp
    
    push rdi

    call Write

    pop rdi

    mov rax, 0
    mov rsp, rbp
    pop rbp
    ret

global ReadFile
ReadFile:
    push rbp
    mov rbp, rsp

    ; Allocate memory for the buffer
    mov rax, [rbp-16]      ; File size
    add rax, 1             ; Add 1 for null terminator
    mov rdi, rax           ; Size of the buffer
    call malloc            ; Allocate memory for the buffer
    mov [rbp-24], rax      ; Store the buffer address

    mov rdi, [rbp-8]       ; File name
    mov rax, 2             ; Syscall number for open
    syscall
    mov [rbp-12], rax      ; Store file descriptor

    cmp rax, -1            ; Check if file was opened successfully
    je .error_open

    ; seek file

    mov rdi, [rbp-12]      ; File descriptor
    xor rsi, rsi           ; Offset (0)
    mov rax, 8             ; Syscall number for lseek
    syscall
    mov [rbp-16], rax      ; Store file size

    cmp rax, -1            ; Check if lseek was successful
    je .error_lseek

    ; read file

    mov rdi, [rbp-12]      ; File descriptor
    mov rsi, [rbp-24]      ; Buffer address
    mov rdx, [rbp-16]      ; Buffer size
    mov rax, 0             ; Syscall number for read
    syscall

    cmp rax, -1            ; Check if read was successful
    je .error_read

    ; Close the file
    mov rdi, [rbp-12]      ; File descriptor
    mov rax, 3             ; Syscall number for close
    syscall

    ; Clean up resources and return
    mov rax, [rbp-24]      ; Buffer address
    mov rsp, rbp
    pop rbp
    ret

.error_open:
    mov rdi, STR0
    call WriteLine
    jmp .cleanup_and_exit

.error_lseek:
    mov rdi, STR1
    call WriteLine
    jmp .cleanup_and_exit

.error_read:
    mov rdi, STR2
    call WriteLine
    jmp .cleanup_and_exit

.cleanup_and_exit:
    ; Close the file if it was opened
    mov rdi, [rbp-12]      ; File descriptor
    cmp rdi, -1            ; Check if file was opened
    je .no_file_to_close
    mov rax, 3             ; Syscall number for close
    syscall
.no_file_to_close:
    ; Free the allocated buffer if it exists
    mov rdi, [rbp-24]      ; Buffer address
    cmp rdi, 0             ; Check if buffer was allocated
    je .no_buffer_to_free
    call free              ; Free the allocated memory
.no_buffer_to_free:
    mov rdi, 1             ; Exit status
    call exit              ; Exit the program

section .data
STR0: db "ERROR: Couldn't open file!", 0
STR1: db "ERROR: Couldn't seek file!", 0
STR2: db "ERROR: Couldn't read file!", 0