using UnityEditor;
using UnityEngine;

public class PostprocessorInspector : EditorWindow
{
    [MenuItem("Tools/FBX Importer/Clear")]
    public static void Clear()
    {
        PostprocessorSetting.Instance.Clear();
    }
    [MenuItem("Tools/FBX Importer/Enabled")]
    public static void IsEnabled()
    {
        PostprocessorSetting.Instance.IsEnabled = !PostprocessorSetting.Instance.IsEnabled;
    }
    [MenuItem("Tools/FBX Importer/Enabled", true)]
    public static bool IsEnabledValidate()
    {
        Menu.SetChecked("Tools/FBX Importer/Enabled", PostprocessorSetting.Instance.IsEnabled);
        return true;
    }
    [MenuItem("Tools/FBX Importer/Settings",true)]
    public static bool OpenValidate()
    {
        return PostprocessorSetting.Instance.IsEnabled;
    }
    [MenuItem("Tools/FBX Importer/Settings")]
    public static void Open()
    {
        PostprocessorInspector inspaector = EditorWindow.CreateInstance<PostprocessorInspector>();
        inspaector.minSize = new Vector2(300f, 500f);
        inspaector.Show();
    }
    
    public const float LABEL_WIDTH = 140;

    public int _toolbarOption = 0;
    public string[] _toolbarTexts = { "Model", "Rig", "Animation", "Materials" };
    private bool _toggleModel;

    public void OnGUI()
    {
        EditorGUILayout.HelpBox("模型导入快速设置工具", MessageType.Warning);
        _toolbarOption = GUILayout.Toolbar(_toolbarOption, _toolbarTexts,GUILayout.Height(30));
        switch (_toolbarOption)
        {
            case 0:
                ModelGUI();
                break;

            case 1:
                RigGUI();
                break;

            case 2:
                AnimationGUI();
                break;

            case 3:
                MaterialsGUI();
                break;
        }
    }

    private void ModelGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            Color color = GUI.color;
            GUI.color = Color.green;
            GUILayout.Label("Meshes", GUILayout.Height(18));
            GUI.color = color;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Scale Factor", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ScaleFactor = EditorGUILayout.FloatField(PostprocessorSetting.Instance.ScaleFactor);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Use File Scale", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.UseFileScale = EditorGUILayout.Toggle(PostprocessorSetting.Instance.UseFileScale);
            }
            EditorGUILayout.EndHorizontal();

            if (PostprocessorSetting.Instance.UseFileScale)
            {
                GUI.enabled = false;
                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.Label("    File Scale", GUILayout.Width(LABEL_WIDTH));
                    PostprocessorSetting.Instance.FileScale = EditorGUILayout.FloatField(PostprocessorSetting.Instance.FileScale);
                }
                EditorGUILayout.EndHorizontal();
                GUI.enabled = true;
            }

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Mesh Compression", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.MeshCompression = (ModelImporterMeshCompression)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.MeshCompression);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Read/Write Enabled", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ReadAndWriteEnabled = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ReadAndWriteEnabled);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Optimize Mesh", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.OptimizeMesh = EditorGUILayout.Toggle(PostprocessorSetting.Instance.OptimizeMesh);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Import BlendShapes", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ImportBlendShapes = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ImportBlendShapes);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Generate Colliders", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.GenerateColliders = EditorGUILayout.Toggle(PostprocessorSetting.Instance.GenerateColliders);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Keep Quads", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.KeepQuads = EditorGUILayout.Toggle(PostprocessorSetting.Instance.KeepQuads);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Weld Vertices", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.WeldVertices = EditorGUILayout.Toggle(PostprocessorSetting.Instance.WeldVertices);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Import Visibility", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ImportVisibility = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ImportVisibility);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Import Cameras", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ImportCameras = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ImportCameras);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Import Lights", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ImportLights = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ImportLights);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Swap UVs", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.SwapUVs = EditorGUILayout.Toggle(PostprocessorSetting.Instance.SwapUVs);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Generate Lightmap UVs", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.GenerateLightmapUVs = EditorGUILayout.Toggle(PostprocessorSetting.Instance.GenerateLightmapUVs);
            }
            EditorGUILayout.EndHorizontal();

            GUI.color = Color.green;
            GUILayout.Label("Normals & Tangents", GUILayout.Height(18));
            GUI.color = color;

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Normals", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.Normals = (ModelImporterTangentSpaceMode)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.Normals);
            }
            EditorGUILayout.EndHorizontal();

            GUI.enabled = PostprocessorSetting.Instance.Normals == ModelImporterTangentSpaceMode.Calculate;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Normals Mode", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.NormalsMode = (ModelImporterNormalCalculationMode)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.NormalsMode);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Smoothing Angle", GUILayout.Width(LABEL_WIDTH));
                float value = PostprocessorSetting.Instance.SmoothingAngle;
                value = GUILayout.HorizontalSlider(value, 0, 180);
                value = EditorGUILayout.FloatField(value, GUILayout.Width(40));
                PostprocessorSetting.Instance.SmoothingAngle = (float)System.Math.Round(value, 1);
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;

            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Tangents", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.Tangents = (ModelImporterTangents)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.Tangents);
            }
            EditorGUILayout.EndHorizontal();
            GUILayout.Space(10);
            GUI.enabled = PostprocessorSetting.Instance.IsChanged;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("");
                if (GUILayout.Button("Revert", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Revert();
                }
                if (GUILayout.Button("Apply", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Save();
                }
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;
        }
        EditorGUILayout.EndVertical();
    }

    private void RigGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            GUI.enabled = false;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Animation Type", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.AnimationType = (ModelImporterAnimationType)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.AnimationType);
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;

            GUILayout.Space(10);
            GUI.enabled = PostprocessorSetting.Instance.IsChanged;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("");
                if (GUILayout.Button("Revert", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Revert();
                }
                if (GUILayout.Button("Apply", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Save();
                }
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;
        }
        EditorGUILayout.EndVertical();
    }

    private void AnimationGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Import Animation", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ImportAnimation = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ImportAnimation);
            }
            EditorGUILayout.EndHorizontal();

            GUILayout.Space(10);
            GUI.enabled = PostprocessorSetting.Instance.IsChanged;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("");
                if (GUILayout.Button("Revert", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Revert();
                }
                if (GUILayout.Button("Apply", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Save();
                }
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;
        }
        EditorGUILayout.EndVertical();
    }

    private void MaterialsGUI()
    {
        EditorGUILayout.BeginVertical();
        {
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("Import Materials", GUILayout.Width(LABEL_WIDTH));
                PostprocessorSetting.Instance.ImportMaterials = EditorGUILayout.Toggle(PostprocessorSetting.Instance.ImportMaterials);
            }
            EditorGUILayout.EndHorizontal();
            if (PostprocessorSetting.Instance.ImportMaterials)
            {
                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Material Naming", GUILayout.Width(LABEL_WIDTH));
                    System.Enum selected =
                    PostprocessorSetting.Instance.MaterialNaming = (ModelImporterMaterialName)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.MaterialNaming);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Material Search", GUILayout.Width(LABEL_WIDTH));
                    System.Enum selected =
                    PostprocessorSetting.Instance.MaterialSearch = (ModelImporterMaterialSearch)EditorGUILayout.EnumPopup(PostprocessorSetting.Instance.MaterialSearch);
                }
                EditorGUILayout.EndHorizontal();
            }

            GUILayout.Space(10);
            GUI.enabled = PostprocessorSetting.Instance.IsChanged;
            EditorGUILayout.BeginHorizontal();
            {
                GUILayout.Label("");
                if (GUILayout.Button("Revert", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Revert();
                }
                if (GUILayout.Button("Apply", GUILayout.Width(60)))
                {
                    PostprocessorSetting.Instance.Save();
                }
            }
            EditorGUILayout.EndHorizontal();
            GUI.enabled = true;
        }
        EditorGUILayout.EndVertical();
    }
}