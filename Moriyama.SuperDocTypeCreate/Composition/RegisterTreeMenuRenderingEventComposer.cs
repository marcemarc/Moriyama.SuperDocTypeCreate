using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.Trees;
namespace Moriyama.SuperDocTypeCreate.Composition
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class RegisterTreeMenuRenderingEventComposer : ComponentComposer<RegisterTreeMenuRenderingEventComponent>
    {
        // nothing needed to be done here!
    }
    public class RegisterTreeMenuRenderingEventComponent : IComponent
    {
        public void Initialize()
        {
            TreeControllerBase.MenuRendering += TreeControllerBase_MenuRendering;
        }

        private void TreeControllerBase_MenuRendering(TreeControllerBase sender, MenuRenderingEventArgs e)
        {
            var tree = sender.TreeAlias;
            if (sender.TreeAlias == "documentTypes")
            {
                //update create option to use the Super Create view
                var existingCreateOption = e.Menu.Items.Where(f => f.Alias == "create").FirstOrDefault();
                if (existingCreateOption != null)
                {
                    existingCreateOption.AdditionalData["actionView"] = "/App_Plugins/Moriyama.SuperDocTypeCreate/create.html";
                }
            }
        }

        public void Terminate()
        {

        }
    }
}
