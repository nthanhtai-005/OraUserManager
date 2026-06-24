using GUI.Interfaces;

namespace GUI.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;

            // Xử lý các sự kiện phân quyền, ẩn hiện nút bấm ở đây trong tương lai
        }
    }
}