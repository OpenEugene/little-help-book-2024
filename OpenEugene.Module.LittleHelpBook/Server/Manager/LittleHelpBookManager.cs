using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using OpenEugene.Module.LittleHelpBook.Repository;

namespace OpenEugene.Module.LittleHelpBook.Manager
{
    public class LittleHelpBookManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly ILittleHelpBookRepository _LittleHelpBookRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public LittleHelpBookManager(ILittleHelpBookRepository LittleHelpBookRepository, IDBContextDependencies DBContextDependencies)
        {
            _LittleHelpBookRepository = LittleHelpBookRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new LittleHelpBookContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new LittleHelpBookContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.LittleHelpBook> LittleHelpBooks = _LittleHelpBookRepository.GetLittleHelpBooks(module.ModuleId).ToList();
            if (LittleHelpBooks != null)
            {
                content = JsonSerializer.Serialize(LittleHelpBooks);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.LittleHelpBook> LittleHelpBooks = null;
            if (!string.IsNullOrEmpty(content))
            {
                LittleHelpBooks = JsonSerializer.Deserialize<List<Models.LittleHelpBook>>(content);
            }
            if (LittleHelpBooks != null)
            {
                foreach(var LittleHelpBook in LittleHelpBooks)
                {
                    _LittleHelpBookRepository.AddLittleHelpBook(new Models.LittleHelpBook { ModuleId = module.ModuleId, Name = LittleHelpBook.Name });
                }
            }
        }
    }
}
