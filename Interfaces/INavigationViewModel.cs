using System.ComponentModel;
using FilterBuilder.Enum;

namespace FilterBuilder.Interfaces {
    public interface INavigationViewModel {
        string Name { get; }
        string Image { get; }
        Enum.View Key { get; }
    }
}