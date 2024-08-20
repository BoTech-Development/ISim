using ISim.MainModels.Project;
using ReactiveUI;
using System.Reactive;
using Avalonia.Platform.Storage;
using System.Collections.Generic;
using ISim.Services;
using System.IO;
using ISim.MainModels;
using Newtonsoft.Json;
using ISim.ViewModels.SchematicEditor;
using ISim.ViewModels.Loader;
using ISim.Views;
using ISim.SchematicEditor.Model;


namespace ISim.ViewModels
{
    public class NewProjectViewModel : ViewModelBase
    {

        private LoadingViewModel loadingViewModel = null;
    

        public ReactiveCommand<int, Unit> ButtonMenuCommand { get; set; }
        public ReactiveCommand<Unit, Unit> BrowseCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CreateSolutionCommand { get; set; }

        private string _solutionPath = "C:\\Users\\Default\\Documents";
        public string SolutionPath
        {
            get => _solutionPath;
            set => this.RaiseAndSetIfChanged(ref _solutionPath, value);
        }

        private string _solutionName = "Solution";
        public string SolutionName
        {
            get => _solutionName;
            set => this.RaiseAndSetIfChanged(ref _solutionName, value);
        }

        private string _solutionType = "Type: Please Select a Project Type...";
        public string SolutionType
        {
            get => _solutionType;
            set => this.RaiseAndSetIfChanged(ref _solutionType, value);
        }
        //private RoutedEvent<RoutedEventArgs> loadedEvent = RoutedEvent.
        //public static readonly RoutedEvent<RoutedEventArgs> TapEvent = RoutedEvent.Register<, RoutedEventArgs>(nameof(Tap), RoutingStrategies.Bubble);

        private int solutionType = 0;

        public NewProjectViewModel()
        {
            
            ButtonMenuCommand = ReactiveCommand.Create<int>(ChangeSolutionType);
            BrowseCommand = ReactiveCommand.Create(ShowSaveFileDialog);
            CreateSolutionCommand = ReactiveCommand.Create(CreateSolution);
            
        }

        public async void ShowSaveFileDialog()
        {
            IStorageProvider storageProvider = StorageService.GetStorageProvider();
            if (storageProvider != null)
            {
                var file = await storageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
                {
                    Title = "Project location",
                    FileTypeChoices = new List<FilePickerFileType> { StorageService.ISimSln },
                    SuggestedFileName = "NewSolution",
                    DefaultExtension = "ISimSln",
                    ShowOverwritePrompt = true
                });
                if(file != null)
                {
                    
                    SolutionPath = file.Path.LocalPath.Replace(file.Name, "");
                    SolutionName = Path.GetFileNameWithoutExtension(file.Name);
                }
            }

            
        }
        private void CreateSolution()
        {
            // if (!Directory.Exists(SolutionPath)) Directory.CreateDirectory(SolutionPath);
            // File.Create(SolutionPath + SolutionName + ".ISimSln");
            loadingViewModel = new LoadingViewModel("Creating new Project");
           
            
            switch (solutionType)
            {
                case 0:
                   // loadingViewModel.ListSubProgresses.Add(new ProgressBarDataTemplate("Creating Objects",))
                    CreateEmptyProject();
                   // SchematicEditorWindowViewModel schematicEditorWindowViewModel = new SchematicEditorWindowViewModel();
                    //SchematicEditorWindow schematicEditorWindow = new SchematicEditorWindow(schematicEditorWindowViewModel, this);
                   // schematicEditorWindow.Show();
                    //while (!schematicEditorWindow.IsLoaded) { }
                    //schematicEditorWindowViewModel.OpenSolution(SolutionPath,SolutionName);
                    break;
                case 1:
                   
                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:

                    break;
            }
        }
        public void ReadyToOpenSolutionEvent()
        {

        }
        public void CreateEmptyProject()
        {
            List<string> projects = new List<string>();
            projects.Add(SolutionPath + SolutionName + "\\" + SolutionName + ".ISimproj");
            Solution solution = new Solution(SolutionName, projects, "Empty", null);
            List<string> SchematicPaths = new List<string>();
            SchematicPaths.Add(SolutionPath + SolutionName + "\\" + SolutionName + ".ISimSch");
            Project mainProject = new Project(SolutionName, SchematicPaths[0], SchematicPaths, null);

            Schematic mainSchematic = new Schematic();

            saveJson(solution, SolutionPath, SolutionName + ".ISimSln");
            saveJson(mainProject, SolutionPath + SolutionName + "\\", SolutionName + ".ISimproj");
            saveJson(mainSchematic, SolutionPath + SolutionName + "\\", SolutionName + ".ISimSch");

            //  Project project = new Project();
        }
        public void saveJson(object obj, string path, string fileName)
        {
            string json = JsonConvert.SerializeObject(obj);
            if (json != null)
            {
                if(!Directory.Exists(path)) Directory.CreateDirectory(path);
                if (!File.Exists(path + fileName))
                {
                    FileStream fs = File.Create(path + fileName);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(json);
                    sw.Close();
                    fs.Close();
                    return;
                }

                FileStream fs2 = new FileStream(path + fileName, FileMode.Append);
                StreamWriter sw2 = new StreamWriter(fs2);
                sw2.WriteLine(json);
                sw2.Close();
                fs2.Close();
                return;
                
            }
        }
        public void ChangeSolutionType(int type)
        {
            solutionType = type;
            switch (type)
            {
                case 0:
                    SolutionType = "Empty Project";
                  //  Project project = new Project();
                    
                    break;
                case 1:
                    SolutionType = "KiCad Project";
                    break;
                case 2:
                    
                    break;
                case 3:

                    break;
                case 4:
                   
                    break;
            }
        }
    }
}
