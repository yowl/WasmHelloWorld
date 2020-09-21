Sample HelloWorld app for CoreRT

- Install CoreRT as per https://github.com/dotnet/corert/blob/master/Documentation/how-to-build-and-run-ilcompiler-in-console-shell-prompt.md and https://github.com/dotnet/corert/blob/master/Documentation/how-to-build-WebAssembly.md

Make sure you can run `build wasm` and it passes the tests.

- Compile this project with (adjust for where you have installed CoreRT) 
```
"E:\GitHub\corert\Tools\dotnetcli\dotnet.exe" msbuild /m /ConsoleLoggerParameters:ForceNoAlign "/p:IlcPath=E:\GitHub\corert\bin\WebAssembly.wasm.Debug" "/p:Configuration=Debug" "/p:OSGroup=WebAssembly" "/p:Platform=wasm"  "/p:FrameworkLibPath=E:\GitHub\corert\bin\WebAssembly.wasm.Debug\lib" "/p:FrameworkObjPath=E:\GitHub\corert\bin\obj\WebAssembly.wasm.Debug\Framework"  /p:NativeCodeGen=wasm WasmHelloWorld.csproj /t:LinkNative
```

- Run with 
```
"%EMSDK%"\node\12.18.1_64bit\bin\node bin\wasm\Debug\netcoreapp3.1\native\WasmHelloWorld.js
```
