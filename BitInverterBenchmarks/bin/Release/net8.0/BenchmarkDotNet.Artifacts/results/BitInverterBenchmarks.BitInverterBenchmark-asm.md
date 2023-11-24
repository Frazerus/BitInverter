## .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
```assembly
; BitInverterBenchmarks.BitInverterBenchmark.Invert()
;     public ulong Invert() => _bitInverter.Invert(12u);
;                              ^^^^^^^^^^^^^^^^^^^^^^^^
       mov       rcx,[rcx+8]
       mov       edx,0C
       cmp       [rcx],ecx
       jmp       qword ptr [7FF83FD3EA78]; BitInverter.BitInverterBase.Invert(UInt64)
; Total bytes of code 17
```
```assembly
; BitInverter.BitInverterBase.Invert(UInt64)
;     ulong output = 0;
;     ^^^^^^^^^^^^^^^^^
;     for (int i = 0; i < 64; i++)
;          ^^^^^^^^^
;       ulong currentBitMask = 1ul << i;
;       ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;         output = output | 0x_00_00_00_00_0_00_00_01;
;         ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
;     return output;
;     ^^^^^^^^^^^^^^
       xor       eax,eax
       xor       ecx,ecx
M01_L00:
       add       rax,rax
       mov       r8d,1
       shlx      r8,r8,rcx
       test      rdx,r8
       jne       short M01_L02
M01_L01:
       inc       ecx
       cmp       ecx,40
       jl        short M01_L00
       ret
M01_L02:
       or        rax,1
       jmp       short M01_L01
; Total bytes of code 37
```

