namespace Manufacturing_Society_App
{
    public static class ViewExtensions
    {
        public static Point GetLocationRelativeTo(this VisualElement view, VisualElement parent)
        {
            if (view == null || parent == null)
                return new Point();

            double x = view.X;
            double y = view.Y;
            VisualElement current = view.Parent as VisualElement;

            while (current != null && current != parent)
            {
                x += current.X;
                y += current.Y;
                current = current.Parent as VisualElement;
            }

            return new Point(x, y);
        }
    }
}
