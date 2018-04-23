using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;

/// <summary>
/// Summary description for XpoHelper
/// </summary>
public static class XpoHelper {
    public static Session GetNewSession() {
        return new Session(DataLayer);
    }

    public static UnitOfWork GetNewUnitOfWork() {
        return new UnitOfWork(DataLayer);
    }

    private readonly static object lockObject = new object();

    static volatile IDataLayer fDataLayer;
    static IDataLayer DataLayer {
        get {
            if (fDataLayer == null) {
                lock (lockObject) {
                    if (fDataLayer == null) {
                        fDataLayer = GetDataLayer();
                    }
                }
            }
            return fDataLayer;
        }
    }

    private static IDataLayer GetDataLayer() {
        XpoDefault.Session = null;

        string conn = AccessConnectionProvider.GetConnectionString(@"|DataDirectory|\db.mdb");
        XPDictionary dict = new DevExpress.Xpo.Metadata.ReflectionDictionary();
        IDataStore store = XpoDefault.GetConnectionProvider(conn, AutoCreateOption.SchemaAlreadyExists);
        dict.GetDataStoreSchema(typeof(Order).Assembly);  // <<< initialize the XPO dictionary 
        IDataLayer dl = new ThreadSafeDataLayer(dict, store);
        return dl;
    }
}
