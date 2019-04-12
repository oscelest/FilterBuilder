using FilterBuilder.Interface;
using GalaSoft.MvvmLight;

namespace FilterBuilder.ViewModel {
    public class SkillGemViewModel : ViewModelBase, INavigationViewModel {
        public string Name { get; } = "Skill Gems";
        public string Image { get; } = "pack://application:,,,/ItemFilterBuilder;component/Resources/Images/SkillGem.png";
        public Enum.View Key { get; } = Enum.View.SKILL_GEM;
    }
}
