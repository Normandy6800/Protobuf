
filepath=$(cd "$(dirname "$0")"; pwd)
cd $filepath

protoc --csharp_out=./proto ./proto/*.proto

cp -f proto/*.cs ../../Assets/Script/Network/msg

rm -rf proto/*.cs
