namespace MarbleUI.Controls.Services
{
    public interface IActionSheetService
    {
        object RefuseCommand { get; }
        object AcceptCommand { get; }
        
        object AcceptParameter { get; set; }
        object RefuseParameter { get; set; }
        
        bool SheetShow { get; set; }
    }
}