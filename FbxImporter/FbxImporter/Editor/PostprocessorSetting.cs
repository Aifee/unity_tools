using UnityEditor;

public class PostprocessorSetting : PlayerPrefsSetting<PostprocessorSetting>
{
    private bool _isEnabled = false;
    public bool IsEnabled
    {
        get
        {
            string key = PlayerPrefsSetting<PostprocessorSetting>.KEY + "Enabled";
            _isEnabled = EditorPrefs.GetBool(key, _isEnabled);
            return _isEnabled;
        }
        set
        {
            _isEnabled = value;
            string key = PlayerPrefsSetting<PostprocessorSetting>.KEY + "Enabled";
            EditorPrefs.SetBool(key, _isEnabled);
        }
    }


    #region Model

    private float _scaleFactor = 1;

    public float ScaleFactor
    {
        get { return _scaleFactor; }
        set
        {
            if (_scaleFactor != value)
            {
                IsChanged = true;
            }
            _scaleFactor = value;
        }
    }

    private bool _useFileScale = true;

    public bool UseFileScale
    {
        get { return _useFileScale; }
        set
        {
            if (_useFileScale != value)
            {
                IsChanged = true;
            }
            _useFileScale = value;
        }
    }

    private float _fileScale = 0.01f;

    public float FileScale
    {
        get { return _fileScale; }
        set
        {
            if (_fileScale != value)
            {
                IsChanged = true;
            }
            _fileScale = value;
        }
    }

    private ModelImporterMeshCompression _meshCompression = ModelImporterMeshCompression.Off;

    public ModelImporterMeshCompression MeshCompression
    {
        get { return _meshCompression; }
        set
        {
            if (_meshCompression != value)
            {
                IsChanged = true;
            }
            _meshCompression = value;
        }
    }

    private bool _readAndWriteEnabled = true;

    public bool ReadAndWriteEnabled
    {
        get { return _readAndWriteEnabled; }
        set
        {
            if (_readAndWriteEnabled != value)
            {
                IsChanged = true;
            }
            _readAndWriteEnabled = value;
        }
    }

    private bool _optimizeMesh = true;

    public bool OptimizeMesh
    {
        get { return _optimizeMesh; }
        set
        {
            if (_optimizeMesh != value)
            {
                IsChanged = true;
            }
            _optimizeMesh = value;
        }
    }

    private bool _importBlendShapes = true;

    public bool ImportBlendShapes
    {
        get { return _importBlendShapes; }
        set
        {
            if (_importBlendShapes != value)
            {
                IsChanged = true;
            }
            _importBlendShapes = value;
        }
    }

    private bool _generateColliders = false;

    public bool GenerateColliders
    {
        get { return _generateColliders; }
        set
        {
            if (_generateColliders != value)
            {
                IsChanged = true;
            }
            _generateColliders = value;
        }
    }

    private bool _keepQuads = false;

    public bool KeepQuads
    {
        get { return _keepQuads; }
        set
        {
            if (_keepQuads != value)
            {
                IsChanged = true;
            }
            _keepQuads = value;
        }
    }

    private bool _weldVertices = true;

    public bool WeldVertices
    {
        get { return _weldVertices; }
        set
        {
            if (_weldVertices != value)
            {
                IsChanged = true;
            }
            _weldVertices = value;
        }
    }

    private bool _importVisibility = true;

    public bool ImportVisibility
    {
        get { return _importVisibility; }
        set
        {
            if (_importVisibility != value)
            {
                IsChanged = true;
            }
            _importVisibility = value;
        }
    }

    private bool _importCameras = true;

    public bool ImportCameras
    {
        get { return _importCameras; }
        set
        {
            if (_importCameras != value)
            {
                IsChanged = true;
            }
            _importCameras = value;
        }
    }

    private bool _importLights = true;

    public bool ImportLights
    {
        get { return _importLights; }
        set
        {
            if (_importLights != value)
            {
                IsChanged = true;
            }
            _importLights = value;
        }
    }

    private bool _swapUVs = false;

    public bool SwapUVs
    {
        get { return _swapUVs; }
        set
        {
            if (_swapUVs != value)
            {
                IsChanged = true;
            }
            _swapUVs = value;
        }
    }

    private bool _generateLightmapUVs = false;

    public bool GenerateLightmapUVs
    {
        get { return _generateLightmapUVs; }
        set
        {
            if (_generateLightmapUVs != value)
            {
                IsChanged = true;
            }
            _generateLightmapUVs = value;
        }
    }

    private ModelImporterTangentSpaceMode _normals = ModelImporterTangentSpaceMode.Import;

    public ModelImporterTangentSpaceMode Normals
    {
        get { return _normals; }
        set
        {
            if (_normals != value)
            {
                IsChanged = true;
            }
            _normals = value;
        }
    }

    private ModelImporterNormalCalculationMode _normalsMode = ModelImporterNormalCalculationMode.AreaAndAngleWeighted;

    public ModelImporterNormalCalculationMode NormalsMode
    {
        get { return _normalsMode; }
        set
        {
            if (_normalsMode != value)
            {
                IsChanged = true;
            }
            _normalsMode = value;
        }
    }

    private float _smoothingAngle = 60f;

    public float SmoothingAngle
    {
        get { return _smoothingAngle; }
        set
        {
            if (_smoothingAngle != value)
            {
                IsChanged = true;
            }
            _smoothingAngle = value;
        }
    }

    private ModelImporterTangents _tangents = ModelImporterTangents.CalculateLegacyWithSplitTangents;

    public ModelImporterTangents Tangents
    {
        get { return _tangents; }
        set
        {
            if (_tangents != value)
            {
                IsChanged = true;
            }
            _tangents = value;
        }
    }

    #endregion Model

    #region Rig

    private ModelImporterAnimationType _animationType = ModelImporterAnimationType.None;

    public ModelImporterAnimationType AnimationType
    {
        get { return _animationType; }
        set
        {
            if (_animationType != value)
            {
                IsChanged = true;
            }
            _animationType = value;
        }
    }

    #endregion Rig

    #region Animation

    private bool _importAnimation = true;

    public bool ImportAnimation
    {
        get { return _importAnimation; }
        set
        {
            if (_importAnimation != value)
            {
                IsChanged = true;
            }
            _importAnimation = value;
        }
    }

    #endregion Animation

    #region Materials

    private bool _importMaterials = true;

    public bool ImportMaterials
    {
        get { return _importMaterials; }
        set
        {
            if (_importMaterials != value)
            {
                IsChanged = true;
            }
            _importMaterials = value;
        }
    }

    private ModelImporterMaterialName _materialNaming = ModelImporterMaterialName.BasedOnTextureName;

    public ModelImporterMaterialName MaterialNaming
    {
        get { return _materialNaming; }
        set
        {
            if (_materialNaming != value)
            {
                IsChanged = true;
            }
            _materialNaming = value;
        }
    }

    private ModelImporterMaterialSearch _materialSearch = ModelImporterMaterialSearch.RecursiveUp;

    public ModelImporterMaterialSearch MaterialSearch
    {
        get { return _materialSearch; }
        set
        {
            if (_materialSearch != value)
            {
                IsChanged = true;
            }
            _materialSearch = value;
        }
    }

    #endregion Materials
}