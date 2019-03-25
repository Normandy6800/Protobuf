::ns:namespace

::echo on
.\tool\ProtoGen\protogen.exe 	-i:file\test.proto 		-o:..\Assets\Scripts\test.cs	-p:import=System;ProtoBuf
@pause
