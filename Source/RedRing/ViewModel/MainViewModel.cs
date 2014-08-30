using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Marimo.RedRing.Model;
using Marimo.RedRing.Model.IO;

namespace Marimo.RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ��� ���f�� { get;private set; }

        public MainViewModel()
            :base(Messenger.Default)
        {
            ���f�� = new ���();

            �����̂�ǉ����� = new RelayCommand(() => ���f��.���f����ǉ�����(new ������()));

            Stl�t�@�C����ǂݍ��� = new RelayCommand(
                () => {
                    MessengerInstance.Send(
                        new FileOpenMessage(
                            async path =>
                    {
                        ���f��.���f����ǉ�����(await StlFile.LoadAsync(path));
                    }));
                });
        }

        public RelayCommand �����̂�ǉ����� { get;private set; }

        public RelayCommand Stl�t�@�C����ǂݍ��� { get;private set; }
    }
}