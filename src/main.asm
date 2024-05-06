; public static void Main(String[] argv){
;     if(argv.Length < 1){
;         Usage();
;         return;
;     }
;     String path = "None";
;     foreach(string arg in argv){
;         if(arg.Equals("-h") || arg.Equals("--help")){
;             Usage();
;             return;
;         } else{
;             if(path != "None"){
;                 Console.WriteLine("ERROR: Multiple input paths provided!\n");
;                 return;
;             }
;             path = arg;
;         }
;     }
;     Console.WriteLine($"{path}");
;     return;
; }
section .text
%include "./src/include/gcc.inc"
%include "./src/include/util.inc"

global Usage
Usage:
    mov rdi, STR0
    call WriteLine

    mov rdi, STR1
    call WriteLine

    mov rdi, STR2
    call WriteLine
    ret

global main
main:
    push rbp
    mov rbp, rsp

    cmp rdi, 1
    jle .not_enough_args
.enough_args:
    mov rdi, [rsi+8*1] ; argv[1]
    call WriteLine
    mov rdi, [rsi+8*1]
    call ReadFile
    mov rdi, rax
    call WriteLine

    mov rax, 0
    jmp .return


.not_enough_args:
    call Usage
    mov rax, 1
.return:
    mov rdi, rax
    call exit


section .data
STR0: db "Usage: zephyr [options] <path>", 0
STR1: db "Options:", 0
STR2: db "    -h, --help", 0