using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RedRing.Model;
using RedRing.Framework.IO;

namespace RedRing.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ��� ���f�� { get; private set; }

    public MainViewModel()
            : base(Messenger.Default)
        {
            ���f�� = new ���();

            �����̂�ǉ����� = new RelayCommand(() => ���f��.���f����ǉ�����(new ������()));

            Inport = new RelayCommand(
                () => {
                    MessengerInstance.Send(
                        new FileOpenMessage(
                            async path =>
                    {
                        var lowerPath = path.ToLower();
                        var token = lowerPath.Split('.');
                        switch (token.GetValue(token.Length - 1))
                        {
                            case "stl":
                                var triangleMesh = await STLFile.LoadAsync(path);
                                ���f��.���f����ǉ�����(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                                break;
                            case "obj":
                                triangleMesh = await OBJFile.LoadAsync(path);
                                ���f��.���f����ǉ�����(new TriangleMesh(triangleMesh.Vertices, triangleMesh.VertexIndices, triangleMesh.VertexNormals));
                                break;
                        }
                    }));
                });

            Export = new RelayCommand(
                () =>
                {
                    MessengerInstance.Send(
                        new FileSaveMessage(
                            async (path, filterIndex) =>
                            {
                                switch(filterIndex)
                                {
                                    case 1:
                                        await STLFile.WriteAsciiAsync(���f��.GetTriangleMeshes(), path);
                                        break;
                                    default:
                                        break;
                                }
                            }));
                });
        }

        public RelayCommand �����̂�ǉ����� { get; private set; }

        public RelayCommand Inport { get; private set; }

        public RelayCommand Export { get; private set; }
    }
}