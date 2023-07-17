using Volo.Abp.Settings;

namespace ShowPlanner.Settings
{
    public class ShowPlannerSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(ShowPlannerSettings.MySetting1));
        }
    }
}
