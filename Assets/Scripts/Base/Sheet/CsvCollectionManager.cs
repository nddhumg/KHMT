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
            LoadSheetContainer();
            return container;
        }
    }

    public static void GenericSheetContainer()
    {
        container = new(new UnityLogger());
        converter = new CsvSheetConverter(path);
    }

    public static async void LoadSheetContainer()
    {
        await container.Bake(converter);
    }

    public async void CreateSheet()
    {
        await container.Store(converter);
    }
}
