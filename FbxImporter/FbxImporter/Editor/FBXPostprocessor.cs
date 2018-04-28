using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class FBXPostprocessor : AssetPostprocessor
{
    public void OnPreprocessModel()
    {
        if (!PostprocessorSetting.Instance.IsEnabled)
            return;
        if (Path.GetExtension(assetPath).ToLower() == ".fbx")
        {
            try
            {
                string fbxFile;
                if (DragAndDrop.paths.Length <= 0)
                {
                    return;
                }
                fbxFile = DragAndDrop.paths[0];
                if (EditorUtility.DisplayDialog("FBX Importer from file", fbxFile, "Import", "Cancel"))
                {
                    ModelImporter modelImporter = assetImporter as ModelImporter;
                    modelImporter.globalScale = PostprocessorSetting.Instance.ScaleFactor;
                    modelImporter.useFileScale = PostprocessorSetting.Instance.UseFileScale;
                    modelImporter.meshCompression = PostprocessorSetting.Instance.MeshCompression;
                    modelImporter.isReadable = PostprocessorSetting.Instance.ReadAndWriteEnabled;
                    modelImporter.optimizeMesh = PostprocessorSetting.Instance.OptimizeMesh;
                    modelImporter.importBlendShapes = PostprocessorSetting.Instance.ImportBlendShapes;
                    modelImporter.addCollider = PostprocessorSetting.Instance.GenerateColliders;
                    modelImporter.keepQuads = PostprocessorSetting.Instance.KeepQuads;
                    modelImporter.weldVertices = PostprocessorSetting.Instance.WeldVertices;
                    modelImporter.importVisibility = PostprocessorSetting.Instance.ImportVisibility;
                    modelImporter.importCameras = PostprocessorSetting.Instance.ImportCameras;
                    modelImporter.importLights = PostprocessorSetting.Instance.ImportLights;
                    modelImporter.swapUVChannels = PostprocessorSetting.Instance.SwapUVs;
                    modelImporter.generateSecondaryUV = PostprocessorSetting.Instance.GenerateLightmapUVs;
                    modelImporter.normalImportMode = PostprocessorSetting.Instance.Normals;
                    modelImporter.normalCalculationMode = PostprocessorSetting.Instance.NormalsMode;
                    modelImporter.normalSmoothingAngle = PostprocessorSetting.Instance.SmoothingAngle;
                    modelImporter.importTangents = PostprocessorSetting.Instance.Tangents;
                    //modelImporter.animationType = PostprocessorSetting.Instance.AnimationType;
                    modelImporter.importAnimation = PostprocessorSetting.Instance.ImportAnimation;
                    modelImporter.importMaterials = PostprocessorSetting.Instance.ImportMaterials;
                    modelImporter.materialName = PostprocessorSetting.Instance.MaterialNaming;
                    modelImporter.materialSearch = PostprocessorSetting.Instance.MaterialSearch;
                    //modelImporter.clipAnimations = (ModelImporterClipAnimation[])List.ToArray(typeof(ModelImporterClipAnimation));
                    EditorUtility.DisplayDialog("Imported fbx finished", "Seccessed!", "OK");
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
    }
}