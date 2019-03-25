#!/usr/bin/python
import os
import string

def gen_files(dir, topdown=True):
    for root, dir, files in os.walk(dir, topdown):
        for name in files:
            pathname = os.path.splitext(os.path.join(root, name))
            if (pathname[1] == ".proto"):
            	newname = name[:-5]+"cs"
                cmd=".\\tool\\ProtoGen\\protogen.exe -i:.\\proto\\"+name+" -o:..\\client\\Msgbody\\"+newname+" -p:detectMissing"
                print(cmd)
                os.system(cmd)

dir = os.getcwd()+"\\proto"
print(dir)
gen_files(dir)
