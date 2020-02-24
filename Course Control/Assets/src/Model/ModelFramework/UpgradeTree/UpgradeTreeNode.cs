using src.Model.ModelFramework.Actionables;

namespace src.Model.ModelFramework.UpgradeTree
{
    public class UpgradeTreeNode<T> where T : ActionKind
    {
        public readonly T NodeValue;
        public readonly UpgradeTreeNode<T> []Children;

        protected UpgradeTreeNode(T nodeValue, UpgradeTreeNode<T> []children)
        {
            NodeValue = nodeValue;
            Children = children;
        }
    }
}