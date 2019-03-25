filepath=$(cd "$(dirname "$0")"; pwd)
$filepath/protoc --csharp_out=$filepath/proto $filepath/proto/*.proto
