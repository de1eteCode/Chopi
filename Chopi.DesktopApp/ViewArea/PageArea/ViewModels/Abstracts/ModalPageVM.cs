namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts
{
    abstract class ModalPageVM : PageVM
    {
        public abstract string ErrorOnApply { get; }
        public virtual void OnApply() { }
        public abstract bool IsApply();
    }
}
