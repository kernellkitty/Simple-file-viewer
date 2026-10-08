using System;

//	определите, при каком условия функция останавливается и возвращает результат;
//	шаг рекурсии: реализуйте логику, при которой функция обрабатывает текущую папку, создаёт для неё элемент интерфейса, а затем вызывает саму себя для каждого вложенного элемента;
//	замените старый код фиксированной вложенности вызовом написанной рекурсивной функции, передав в неё корневой элемент (выбранную папку).

namespace skebobus
{
    public void ShowRecursive(string path, TreeViewItem parent)
    {
        DirectoryInfo dir = new DirectoryInfo(path);

        TreeViewItem root = new TreeViewItem();
        root.Header = "📁" + dir.Name;
        tree.Items.Add(root);

        string[] folder_sub = Directory.GetDirectories(path);
        string[] file_sub = Directory.GetFiles(path);

        foreach (string file in file_sub)
        {
            FileInfo s_file = new FileInfo(file);
            TreeViewItem file_node = new TreeViewItem();
            file_node.Header = "📁" + s_file.Name;
            root.Items.Add(file_node);
        }

        foreach (string folder in folder_sub)
        {            

            ShowRecursive(folder, root);
        }
    }
}