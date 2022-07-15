using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsMDI2;
[TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<AbstractMdiWin, UserControl>))]
abstract public class AbstractMdiWin : UserControl, IMdiWin
{
    public AbstractMdiWin()
    {
        DoubleBuffered = true;
        NotMove = true;
        IsMove = false;
    }

    protected bool IsMove { get; set; }
    private MdiControl? mdiControl;
    public MdiControl MdiControl
    {
        get
        {
            if (mdiControl is not null)
                return mdiControl;
            else
                throw new Exception("MdiControl is null");
        }

        set
        {
            mdiControl = value;
        }
    }
    public bool IsMinNotMove { get; protected set; }
    public bool NotMove { get; protected set; }
    public int MinInd { get; protected set; }
    public abstract bool MdiFocus { get; set; }
    public abstract void SetIco(Image ico);
    public abstract void SetMaximizeBox(bool maximizeBox);
    public abstract void SetMinimizeBox(bool minimizeBox);
    public abstract void SetTitle(string title);
}

public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
{
    public AbstractControlDescriptionProvider()
        : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
    {
    }

    public override Type GetReflectionType(Type objectType, object? instance)
    {
        if (objectType == typeof(TAbstract))
            return typeof(TBase);

        return base.GetReflectionType(objectType, instance);
    }

    public override object? CreateInstance(IServiceProvider? provider, Type objectType, Type[]? argTypes, object[]? args)
    {
        if (objectType == typeof(TAbstract))
            objectType = typeof(TBase);

        return base.CreateInstance(provider, objectType, argTypes, args);
    }
}