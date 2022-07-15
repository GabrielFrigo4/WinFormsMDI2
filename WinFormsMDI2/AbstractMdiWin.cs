using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
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
        ChildrenMouseDown = delegate { MdiControl.FocusMdiWin(this); };
        MouseDown += delegate { ChildrenMouseDown.Invoke(); };
    }

    private Action ChildrenMouseDown { get; set; }

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

    #region behaviors
#pragma warning disable SYSLIB0003 // O tipo ou membro é obsoleto
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
#pragma warning restore SYSLIB0003 // O tipo ou membro é obsoleto
    protected override void WndProc(ref Message m)
    {
        // 0x210 is WM_PARENTNOTIFY
        // 513 is WM_LBUTTONCLICK
        if (m.Msg == 0x210 && m.WParam.ToInt32() == 513)
        {
            // get the clicked position
            int x = m.LParam.ToInt32() & 0xFFFF;
            int y = m.LParam.ToInt32() >> 16;

            // get the clicked control
            Control childControl = GetChildAtPoint(new Point(x, y));

            // call onClick (which fires Click event)
            ChildrenMouseDown.Invoke();

            // do something else...
        }
        base.WndProc(ref m);
    }
    #endregion
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