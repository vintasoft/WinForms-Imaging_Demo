using Vintasoft.Imaging;
using Vintasoft.Imaging.UI.VisualTools.UserInteraction;
using Vintasoft.Imaging.UI;

namespace ImagingDemo.Barcode
{
    /// <summary>
    /// Represents a panel with interaction buttons.
    /// </summary>
    internal class InteractionButtonsPanel : InteractionControllerBase<IInteractiveObject>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionButtonsPanel"/> class. 
        /// </summary>
        /// <param name="interactiveObject">Interactive object with
        /// which this interaction button is linked.</param>
        /// <param name="buttons">Array of interaction buttons.</param>
        internal InteractionButtonsPanel(
            IInteractiveObject interactiveObject,
            params InteractionButton[] buttons)
            : base(interactiveObject)
        {
            InteractionAreaList.AddRange(buttons);
        }

        #endregion



        #region Methods

        /// <summary>
        /// Updates the interaction buttons of the panel.
        /// </summary>
        public override void UpdateInteractionAreas(ImageViewer viewer)
        {
            float distance = 1;
            float x = 0;
            foreach (InteractionButton button in InteractionAreaList)
            {
                button.X = x;
                if (button.Image != null)
                    x += button.Image.Width + distance;
            }
        }

        /// <summary>
        /// Performs an interaction between user and the panel.
        /// </summary>
        /// <param name="args">An interaction event args.</param>
        protected override void PerformInteraction(InteractionEventArgs args)
        {
        }

        #endregion

    }
}
