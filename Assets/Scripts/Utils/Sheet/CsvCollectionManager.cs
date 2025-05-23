using Cathei.BakingSheet.Unity;
using Cathei.BakingSheet;
using UnityEngine;
using Microsoft.Extensions.Logging;

[CreateAssetMenu(menuName = ("SO/Tool/CsvManager"))]
public class CsvCollectionManager : ScriptableObject
{
    [SerializeField] private static string path = "Assets/Csv";
    private static CsvSheetConverter converter;
    private static SheetContainer container;

    public static SheetContainer Container
    {
        get
        {
            if (container != null)
            {
                LoadSheetContainer();
                return container;
            }
            GenericSheetContainer();
            return container;
        }
    }

    [Button]
    public static void GenericSheetContainer()
    {
        container = new(new UnityLogger());
        converter = new CsvSheetConverter(path);
        LoadSheetContainer();
    }

    public static async void LoadSheetContainer()
    {
        await container.Bake(converter);
    }

    [Button]
    public async void CreateSheet()
    {
        GenericSheetContainer();
        await container.Store(converter);
    }
}
