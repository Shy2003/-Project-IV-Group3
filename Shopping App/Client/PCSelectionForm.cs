using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*public partial class PCSelectionForm : Form
{
    // Define a delegate type for handling PC selection
    public delegate void PCSelectedEventHandler(object sender, string pcNumber);

    // Define an event based on the delegate
    public event PCSelectedEventHandler PCSelected;

    // Constructor or any method where you handle PC selection
    private void OnPCSelected(string pcNumber)
    {
        // Raise the PCSelected event with the selected PC number
        PCSelected?.Invoke(this, pcNumber);
    }
}*/


/*namespace Client_PC01
{
    public partial class PCSelectionForm : Form
    {
        // Define an event for PC selection
        public event EventHandler<string> PCSelected;

        // Constructor
        public PCSelectionForm()
        {
            InitializeComponent();
        }

        // Event handler for the button click event to select PC
        private void PCButton_Click(object sender, EventArgs e)
        {
            // Get the PC number from the button's text
            string pcNumber = ((Button)sender).Text;

            // Raise the PCSelected event with the selected PC number
            PCSelected?.Invoke(this, pcNumber);

            // Close the PCSelectionForm
            this.Close();
        }
    }
}
*/

namespace Client_PC01
{
    public partial class PCSelectionForm : Form
    {
        // Define an event for PC selection
        public event EventHandler<string> PCSelected;

        // Constructor
        public PCSelectionForm()
        {
            InitializeComponent();
            AddPCButtons();
        }

        // Method to add PC buttons dynamically
        private void AddPCButtons()
        {
            // Create and configure buttons for each PC
            for (int i = 1; i <= 4; i++)
            {
                Button pcButton = new Button();
                pcButton.Text = "PC0" + i;
                pcButton.Size = new Size(100, 50);
                pcButton.Location = new Point(50, 50 + (i - 1) * 70);
                pcButton.Click += PCButton_Click; // Attach event handler
                Controls.Add(pcButton); // Add button to form's controls
            }
        }

        // Event handler for the button click event to select PC
        private void PCButton_Click(object sender, EventArgs e)
        {
            // Get the PC number from the button's text
            string pcNumber = ((Button)sender).Text;

            // Raise the PCSelected event with the selected PC number
            PCSelected?.Invoke(this, pcNumber);

            // Close the PCSelectionForm
            this.Close();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // PCSelectionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 402);
            Margin = new Padding(4, 5, 4, 5);
            Name = "PCSelectionForm";
            Text = "PC Selection";
            Load += PCSelectionForm_Load;
            ResumeLayout(false);
        }

        private void PCSelectionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
