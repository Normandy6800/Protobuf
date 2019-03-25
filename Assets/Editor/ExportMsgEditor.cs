using UnityEngine;
using System.Diagnostics;
using UnityEditor;

public class ExportMsgEditor {

    [MenuItem("Tools/Export Msg")]
    static void ExportMsg()
    {
        Process p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.RedirectStandardOutput = true;
#if UNITY_EDITOR_OSX
        p.StartInfo.FileName = "/bin/bash";
        p.StartInfo.Arguments = Application.dataPath.Replace("Assets", "") + "Tool/protoTool/make_cs.sh";
#else
        p.StartInfo.FileName = "";
#endif
        p.Start();

        p.BeginOutputReadLine();
        string error = p.StandardError.ReadToEnd();
        p.WaitForExit();
        UnityEngine.Debug.Log(error);

        AssetDatabase.Refresh();
    }
}
