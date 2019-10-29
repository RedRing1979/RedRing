using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RedRing.Model;
using RedRing.Framework.IO;

namespace RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ��� ���f�� { get;private set; }

        public MainViewModel()
            :base(Messenger.Default)
        {
            ���f�� = new ���();

            �����̂�ǉ����� = new RelayCommand(() => ���f��.���f����ǉ�����(new ������()));

            STL�t�@�C����ǂݍ��� = new RelayCommand(
                () => {
                    MessengerInstance.Send(
                        new FileOpenMessage(
                            async path =>
                    {
                        var triangleMesh = await STLFile.LoadAsync(path);
                        ���f��.���f����ǉ�����(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                    }));
                });
        }

        public RelayCommand �����̂�ǉ����� { get; private set; }

        public RelayCommand STL�t�@�C����ǂݍ��� { get; private set; }
    }
}