using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JunkImporter.JunkImports.Protect.Junk;

namespace JunkImporter.JunkImports.Protect {
    internal class AddJunk {
        private readonly ModuleDefMD _targetModule;

        public AddJunk(ModuleDefMD module) {
            _targetModule = module;
        }

        public async Task<bool> ImportJunk() {
            try {
                // import types from the junk classes
                var junkTypes = new[]
                {
                    typeof(ImportMethodsWithoutParams),
                    typeof(ImportReturnMethodsWithoutParams),
                    //typeof(ImportMethodsWithParams)
                };

                foreach(var junkType in junkTypes) {
                    var sourceModule = ModuleDefMD.Load(junkType.Module);
                    var sourceType = sourceModule.ResolveTypeDef(MDToken.ToRID(junkType.MetadataToken));

                    foreach(var targetType in _targetModule.Types.Where(t => !t.IsGlobalModuleType)) {
                        var injectedMembers = InjectHelper.Inject(sourceType, targetType, _targetModule);

                        // change the names of teh imported methods to a random string
                        foreach(var method in injectedMembers.OfType<MethodDef>()) {
                            if(method.Name.Contains("<") || method.Name.Contains(">"))
                                continue; 
                            method.Name = "" + Guid.NewGuid().ToString("N").Substring(0, 8);
                            Console.WriteLine($"[+] Injected junk method into {targetType.Name}: {method.Name}");
                        }
                    }
                }

                return true;
            } catch(Exception ex) {
                Console.WriteLine($"[-] Junk injection failed: {ex.Message}");
                return false;
            }
        }
    }
}