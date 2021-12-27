namespace Chopi.DesktopApp.ViewArea.PageArea.ViewModels.Abstracts
{
    abstract class ModalPageVM : PageVM
    {
        public virtual string ErrorOnApply => "Данные не соответствуют полям";
        public virtual void OnApply() { }
        public abstract bool IsApply();
    }
}
