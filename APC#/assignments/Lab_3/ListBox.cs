class ListBox : Window
{
    // constructor adds a parameter
    public ListBox(int top, int left, string contents)
       : base(top, left) // call base constructor
    {
        listBoxContents = contents;
    }
    // an overridden version (note keyword) because in the
    // derived method we change the behavior
    public override void DrawWindow()
    {
        base.DrawWindow(); // invoke the base method
        Console.WriteLine("Writing string to the listbox:{0}",
            listBoxContents);
    }
    private string listBoxContents; // new member variable
}
