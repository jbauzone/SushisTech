using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Eutech.SushisTech.DAL.Context {

    public class ContextDAO {

        private static ConcurrentDictionary<string, SushisContext> _listDataContext { get; set; }

        static ContextDAO() {
            _listDataContext = new ConcurrentDictionary<string, SushisContext>();
        }

        /// <summary>
        /// Création d'un contexte avec les options par défaut
        /// </summary>
        /// <returns></returns>
        private static SushisContext Create() {

            SushisContext context = new SushisContext();
            context.Configuration.AutoDetectChangesEnabled = false;

            return context;
        }

        /// <summary>
        /// Persistence en bdd des données insérée
        /// </summary>
        public static void Save() {
            ContextDAO.Context.SaveChanges();
        }
        
        /// <summary>
        /// Retourne le contexte utilisé pour la session en cours
        /// </summary>
        internal static SushisContext Context {
            
            get {

                SushisContext context = null;

                if (HttpContext.Current != null && HttpContext.Current.Session != null) {


                    // Application Client Web.
                    if (_listDataContext.ContainsKey(HttpContext.Current.GetHashCode().ToString("x")))
                        context = _listDataContext[HttpContext.Current.GetHashCode().ToString("x")];
                    else {
                        context = Create();
                        _listDataContext.GetOrAdd(HttpContext.Current.GetHashCode().ToString("x"), context);
                    }
                } else {
                  
                    // Application Windows / services
                    if (_listDataContext.ContainsKey("AppliWin"))
                        context = _listDataContext["AppliWin"];
                    else {
                        context = Create();
                        _listDataContext.GetOrAdd("AppliWin", context);
                    }
                }

                return context;
            }
        }
        
        /// <summary>
        /// Supprime le contexte de la liste
        /// </summary>
        /// <param name="aDataContextId"></param>
        public static void Delete(string aDataContextId) {

            if (_listDataContext.ContainsKey(aDataContextId)) {

                SushisContext context;

                _listDataContext[aDataContextId].Dispose();
                _listDataContext.TryRemove(aDataContextId, out context);
            }
        }
    }
}
