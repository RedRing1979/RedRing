using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Marimo.RedRing.Model;

namespace Marimo.RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ��� ���f�� { get;private set; }

        public MainViewModel()
        {
            ���f�� = new ���();

            �����̂�ǉ����� = new RelayCommand(() => ���f��.���f����ǉ�����(new ������()));
        }

        public RelayCommand �����̂�ǉ����� { get;private set; }
    }
}