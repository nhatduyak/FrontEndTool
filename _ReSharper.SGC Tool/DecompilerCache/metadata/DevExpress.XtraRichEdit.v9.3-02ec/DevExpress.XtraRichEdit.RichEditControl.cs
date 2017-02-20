// Type: DevExpress.XtraRichEdit.RichEditControl
// Assembly: DevExpress.XtraRichEdit.v9.3, Version=9.3.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a
// Assembly location: C:\Program Files\DevExpress 2009.3\Components\Sources\DevExpress.DLL\DevExpress.XtraRichEdit.v9.3.dll

using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.About;
using DevExpress.Utils.Controls;
using DevExpress.Utils.KeyboardHandler;
using DevExpress.Utils.Menu;
using DevExpress.Utils.Serializing;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.API.Native.Implementation;
using DevExpress.XtraRichEdit.Commands;
using DevExpress.XtraRichEdit.Drawing;
using DevExpress.XtraRichEdit.Forms;
using DevExpress.XtraRichEdit.Internal;
using DevExpress.XtraRichEdit.Keyboard;
using DevExpress.XtraRichEdit.Layout.Engine;
using DevExpress.XtraRichEdit.Menu;
using DevExpress.XtraRichEdit.Model;
using DevExpress.XtraRichEdit.Mouse;
using DevExpress.XtraRichEdit.Native;
using DevExpress.XtraRichEdit.Painters;
using DevExpress.XtraRichEdit.Ruler;
using DevExpress.XtraRichEdit.SpellChecker;
using DevExpress.XtraRichEdit.Utils;
using DevExpress.XtraSpellChecker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DevExpress.XtraRichEdit
{
    [ToolboxTabName("DX.9.3: Rich Text Editor")]
    [ToolboxBitmap(typeof (RichEditControl), "Bitmaps256.RichTextControl.bmp")]
    [LicenseProvider(typeof (DXRichEditLicenseProvider))]
    [ToolboxItem(true)]
    [ComVisible(false)]
    [Designer("DevExpress.XtraRichEdit.Design.XtraRichEditDesigner,DevExpress.XtraRichEdit.v9.3.Design")]
    [Docking(DockingBehavior.Ask)]
    public class RichEditControl : Control, IPrintable, IBasePrintable, ISupportLookAndFeel, IToolTipControlClient,
                                   IBatchUpdateable, IBatchUpdateHandler, IServiceContainer, IServiceProvider,
                                   INativeDocumentOwner
    {
        public RichEditControl();
        protected override Size DefaultSize { get; }
        protected internal Caret Caret { get; }
        protected internal Timer CaretTimer { get; }
        protected internal Timer VerticalScrollBarUpdateTimer { get; }
        protected internal HorizontalRulerControl HorizontalRuler { get; }
        protected internal VerticalRulerControl VerticalRuler { get; }

        [Browsable(false)]
        public float DpiX { get; }

        [Browsable(false)]
        public float DpiY { get; }

        protected internal RichEditControlPainter Painter { get; }

        [Description("Gets or sets the border style for the RichEdit control.")]
        [XtraSerializableProperty(XtraSerializationFlags.DefaultValue)]
        [DefaultValue(7)]
        [Category("Appearance")]
        public BorderStyles BorderStyle { get; set; }

        protected internal Rectangle ClientBounds { get; }
        protected internal Rectangle BackgroundBounds { get; }
        protected internal Rectangle CornerBounds { get; }
        protected internal Rectangle ViewBounds { get; }
        protected internal SearchTextForm SearchForm { get; }
        protected internal RichEditViewBackgroundPainter BackgroundPainter { get; }
        protected internal RichEditViewPainter ViewPainter { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Image BackgroundImage { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ImageLayout BackgroundImageLayout { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public override Color ForeColor { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color BackColor { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font { get; set; }

        [Description("Provides access to the object containing appearance settings for the control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RichEditAppearance Appearance { get; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override RightToLeft RightToLeft { get; set; }

        [Description("Gets or sets the menu manager which controls the look and feel of context menus.")]
        [DefaultValue(null)]
        public IDXMenuManager MenuManager { get; set; }

        [Description(
            "Gets or sets the tooltip controller component that controls the appearance, position and the content of the hints displayed by the RichEditControl."
            )]
        [Category("Appearance")]
        [DefaultValue(null)]
        public ToolTipController ToolTipController { get; set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DefaultValue(true)]
        public override bool AllowDrop { get; set; }

        [DefaultValue(0)]
        public DragDropMode DragDropMode { get; set; }

        protected internal IPrintable PrintableImplementation { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsPrintingAvailable { get; }

        protected internal KeyboardHandler KeyboardHandler { get; }
        protected internal MouseHandler MouseHandler { get; }
        protected internal Stack<MouseHandler> MouseHandlers { get; }
        protected internal Stack<KeyboardHandler> KeyboardHandlers { get; }
        protected internal PredefinedFontSizeCollection PredefinedFontSizeCollection { get; }
        protected internal int ThreadId { get; }
        protected internal BackgroundThreadUIUpdater BackgroundThreadUIUpdater { get; }
        protected internal DocumentDeferredChanges DeferredChanges { get; }
        protected internal MeasurementAndDrawingStrategy MeasurementAndDrawingStrategy { get; }
        protected internal BoxMeasurer Measurer { get; }

        [Browsable(false)]
        public DocumentModelAccessor Model { get; }

        protected internal DocumentModel DocumentModel { get; }
        protected internal DocumentModel DocumentModelTemplate { get; }
        protected internal BackgroundFormatter Formatter { get; }

        [NotifyParentProperty(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RichEditControlOptions Options { get; }

        [Description("Gets or sets the component used for spelling check by the RichEdit control.")]
        [DefaultValue(null)]
        public ISpellChecker SpellChecker { get; set; }

        [DefaultValue(false)]
        [Browsable(false)]
        public bool Modified { get; set; }

        [Description("Contains settings of the Views that are used to display a document in the RichEdit Control. ")]
        [XtraSerializableProperty(XtraSerializationVisibility.Content, XtraSerializationFlags.DefaultValue)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RichEditViewRepository Views { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public RichEditView ActiveView { get; }

        [Description("Gets or sets the type of the View which is currently used by the RichEdit to show the document. ")
        ]
        public RichEditViewType ActiveViewType { get; set; }

        [Browsable(false)]
        public virtual RichEditViewType DefaultViewType { get; }

        [Description("Gets or sets whether document modifications are prohibited.")]
        [DefaultValue(false)]
        public bool ReadOnly { get; set; }

        [Description("Gets or sets the plain text content of the control.")]
        public override string Text { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [Bindable(true)]
        public string RtfText { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true)]
        [Browsable(false)]
        public string HtmlText { get; set; }

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string MhtText { get; set; }

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string WordMLText { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Bindable(true)]
        [Browsable(false)]
        public byte[] OpenXmlBytes { get; set; }

        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public byte[] OpenDocumentBytes { get; set; }

        [Browsable(false)]
        public DevExpress.XtraRichEdit.API.Native.Document Document { get; }

        protected internal NativeDocument NativeDocument { get; }
        protected internal DocumentUnit UIUnit { get; }
        protected internal bool ForceUpdateUIOnIdle { get; set; }
        protected internal bool UpdateUIOnIdle { get; set; }

        #region IBatchUpdateable Members

        public void BeginUpdate();
        public void EndUpdate();
        public void CancelUpdate();
        BatchUpdateHelper IBatchUpdateable.BatchUpdateHelper { get; }

        [Browsable(false)]
        public bool IsUpdateLocked { get; }

        #endregion

        #region IBatchUpdateHandler Members

        void IBatchUpdateHandler.OnFirstBeginUpdate();
        void IBatchUpdateHandler.OnBeginUpdate();
        void IBatchUpdateHandler.OnEndUpdate();
        void IBatchUpdateHandler.OnLastEndUpdate();
        void IBatchUpdateHandler.OnCancelUpdate();
        void IBatchUpdateHandler.OnLastCancelUpdate();

        #endregion

        #region INativeDocumentOwner Members

        [DefaultValue(0)]
        [Description("Gets or sets a unit of measure used within the control.")]
        public DocumentUnit Unit { get; set; }

        #endregion

        #region IPrintable Members

        void IPrintable.AcceptChanges();
        void IPrintable.RejectChanges();
        bool IPrintable.HasPropertyEditor();
        void IPrintable.ShowHelp();
        bool IPrintable.SupportsHelp();
        void IBasePrintable.Initialize(IPrintingSystem ps, ILink link);
        void IBasePrintable.CreateArea(string areaName, IBrickGraphics graphics);
        void IBasePrintable.Finalize(IPrintingSystem ps, ILink link);
        bool IPrintable.CreatesIntersectedBricks { get; }
        UserControl IPrintable.PropertyEditorControl { get; }

        #endregion

        #region IServiceContainer Members

        public void AddService(System.Type serviceType, ServiceCreatorCallback callback, bool promote);
        public void AddService(System.Type serviceType, ServiceCreatorCallback callback);
        public void AddService(System.Type serviceType, object serviceInstance, bool promote);
        public void AddService(System.Type serviceType, object serviceInstance);
        public void RemoveService(System.Type serviceType, bool promote);
        public void RemoveService(System.Type serviceType);
        public new virtual object GetService(System.Type serviceType);

        #endregion

        #region ISupportLookAndFeel Members

        bool ISupportLookAndFeel.IgnoreChildren { get; }

        [Description("Provides access to the settings that specify the RichEdit control\'s look and feel.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Appearance")]
        public UserLookAndFeel LookAndFeel { get; }

        #endregion

        #region IToolTipControlClient Members

        ToolTipControlInfo IToolTipControlClient.GetObjectInfo(Point point);
        bool IToolTipControlClient.ShowToolTips { get; }

        #endregion

        protected internal virtual void RaiseBeforeDispose();
        protected internal virtual void RaiseSearchFormShowing(SearchFormShowingEventArgs e);
        protected internal virtual RichEditPopupMenu RaisePreparePopupMenu(RichEditPopupMenu menu);
        protected internal virtual void EndInitialize();
        protected internal virtual void SubscribeToolTipControllerEvents(ToolTipController controller);
        protected internal virtual void UnsubscribeToolTipControllerEvents(ToolTipController controller);
        protected internal virtual void OnToolTipControllerDisposed(object sender, EventArgs e);
        protected internal virtual void RegisterToolTipClientControl(ToolTipController controller);
        protected internal virtual void UnregisterToolTipClientControl(ToolTipController controller);
        protected internal virtual RichEditControlPainter CreatePainter();
        protected internal virtual MeasurementAndDrawingStrategy CreateMeasurementAndDrawingStrategy();
        protected internal virtual void InitializeCaretTimer();
        protected internal virtual void DestroyCaretTimer();
        protected internal virtual void InitializeVerticalScrollBarUpdateTimer();
        protected internal virtual void DestroyVerticalScrollBarUpdateTimer();
        protected internal virtual void OnVerticalScrollBarUpdateTimerTick(object sender, EventArgs e);
        protected internal virtual void OnCaretTimerTick(object sender, EventArgs e);
        public virtual void ShowSearchForm();
        public virtual void ShowReplaceForm();
        protected internal virtual void ShowSearchForm(SearchFormActivePage activePage);
        protected internal virtual void SubscribeSearchFormEvents();
        protected internal virtual void UnsubscribeSearchFormEvents();
        protected internal virtual void OnSearchFormClosed(object sender, FormClosedEventArgs e);
        protected internal virtual SearchTextForm CreateSearchForm(SearchFormActivePage activePage);
        protected internal virtual void ShowInsertMergeFieldForm();
        protected internal virtual void OnOptionsChangedPlatformSpecific(BaseOptionChangedEventArgs e);
        protected internal virtual void ShowCaret();
        protected internal virtual void ShowCaretCore();
        protected internal virtual void HideCaret();
        protected internal virtual void HideCaretCore();
        protected internal virtual void DeactivateViewPlatformSpecific(RichEditView view);
        protected internal virtual void ActivateViewPlatformSpecific(RichEditView view);
        protected internal virtual void DisposeBackgroundPainter();
        protected internal virtual void CreateBackgroundPainter(RichEditView view);
        protected internal virtual void RecreateBackgroundPainter(RichEditView view);
        protected internal virtual void DisposeViewPainter();
        protected internal virtual void CreateViewPainter(RichEditView view);
        protected internal virtual void RecreateViewPainter(RichEditView view);
        public static void About();
        protected override void Dispose(bool disposing);
        protected internal virtual void DisposeCore();
        protected override void OnHandleCreated(EventArgs e);
        protected override void OnBindingContextChanged(EventArgs e);
        protected override void OnHandleDestroyed(EventArgs e);
        protected internal virtual void OnApplicationIdle(object sender, EventArgs e);
        protected override void OnPaint(PaintEventArgs e);
        protected internal virtual void Redraw();
        protected internal virtual void RedrawEnsureSecondaryFormattingComplete();
        protected override void OnPaintBackground(PaintEventArgs pevent);
        protected override void OnResize(EventArgs e);
        protected internal virtual Rectangle CalculateInitialClientBounds();
        protected internal virtual int CalculateVerticalRulerWidth();
        protected internal virtual int CalculateHorizontalRulerHeight();
        protected internal virtual int CalculateVerticalScrollbarWidth();
        protected internal virtual int CalculateHorizontalScrollbarHeight();
        protected internal virtual void UpdateRulers();
        protected internal virtual bool CalculateVerticalRulerVisibility();
        protected internal virtual bool CalculateHorizontalRulerVisibility();
        protected internal virtual void UpdateScrollbarsVisibility();
        protected internal virtual bool CalculateVerticalScrollbarVisibility();
        protected internal virtual bool CalculateHorizontalScrollbarVisibility();
        protected internal virtual void OnDeferredResizeCore();
        protected internal virtual void OnResizeCore();
        protected internal virtual bool PerformResize(Rectangle initialClientBounds);
        protected internal virtual void OnViewPaddingChanged();
        protected override bool ProcessDialogChar(char charCode);
        protected override bool IsInputKey(Keys keyData);
        protected internal bool IsAltGrPressed();
        protected override void OnKeyDown(KeyEventArgs e);
        protected override void OnKeyUp(KeyEventArgs e);
        protected override void OnKeyPress(KeyPressEventArgs e);
        protected override void OnMouseMove(MouseEventArgs e);
        protected override void OnMouseDown(MouseEventArgs e);
        protected override void OnMouseUp(MouseEventArgs e);
        protected override void OnMouseWheel(MouseEventArgs e);
        protected override void OnDragEnter(DragEventArgs e);
        protected override void OnDragOver(DragEventArgs e);
        protected override void OnDragDrop(DragEventArgs e);
        protected override void OnDragLeave(EventArgs e);
        protected override void OnGiveFeedback(GiveFeedbackEventArgs e);
        protected override void OnQueryContinueDrag(QueryContinueDragEventArgs e);
        protected internal virtual void OnEndDocumentUpdate(object sender, DocumentUpdateCompleteEventArgs e);
        protected internal virtual void ApplyChangesCorePlatformSpecific(DocumentModelChangeActions changeActions);
        protected internal virtual void RaiseDeferredEvents(DocumentModelChangeActions changeActions);
        protected internal virtual Rectangle CalculateViewBounds(Rectangle clientBounds);
        protected internal virtual Rectangle CalculateActualViewBounds(Rectangle previousViewBounds);
        protected override void OnGotFocus(EventArgs e);
        protected override void OnLostFocus(EventArgs e);
        protected override void OnEnabledChanged(EventArgs e);
        protected override void OnVisibleChanged(EventArgs e);
        public virtual void LoadDocument(string fileName);
        public virtual void LoadDocument(string fileName, DocumentFormat documentFormat);
        public virtual void SaveDocument(string fileName, DocumentFormat documentFormat);
        public virtual void LoadDocument(IWin32Window parent);
        public virtual void SaveDocument();
        public virtual void SaveDocument(IWin32Window parent);
        protected internal virtual IPrintable LoadIPrintableImplementation();
        protected internal virtual void CheckPrintableImplmenentation();
        protected internal virtual ConstructorInfo ObtainPrinterConstructor();
        public void ShowPrintPreview();
        public void ShowPrintDialog();
        public void Print();
        protected internal virtual void BeginScrollbarUpdate(ScrollBarBase scrollbar);
        protected internal virtual void EndScrollbarUpdate(ScrollBarBase scrollbar);
        protected internal virtual void SubscribeLookAndFeelEvents();
        protected internal virtual void UnsubscribeLookAndFeelEvents();
        protected internal virtual void OnLookAndFeelChanged(object sender, EventArgs e);
        protected internal virtual void SubscribeAppearanceEvents();
        protected internal virtual void UnsubscribeAppearanceEvents();
        protected internal virtual void OnAppearanceChanged(object sender, EventArgs e);
        protected internal virtual bool ShouldApplyForeColor();
        protected internal virtual bool ShouldApplyFont();
        protected internal virtual void OnBorderStyleChanged();
        protected internal virtual void OnZoomFactorChangingPlatformSpecific();
        protected override void WndProc(ref Message m);
        protected internal virtual void OnWmContextMenu(ref Message m);
        protected internal virtual Point CalculatePopupMenuPosition(Point screenMousePosition);
        protected internal virtual void OnPopupMenu(Point point);
        public bool IsImeWindowOpen();
        public void CloseImeWindow(ImeCloseStatus closeSatus);
        protected internal virtual Point GetPhysicalPoint(Point point);
        protected internal virtual bool IsHyperlinkActive();
        protected internal virtual bool ShouldSerializeActiveViewType();
        protected internal virtual void ResetActiveViewType();
        protected internal new virtual bool ShouldSerializeText();
        public override void ResetText();
        protected internal virtual void RaiseActiveViewChanged();
        protected internal virtual void RaiseSelectionChanged();
        protected internal virtual void RaiseDocumentLoaded();
        protected internal virtual void RaiseEmptyDocumentCreated();
        protected internal virtual bool RaiseDocumentClosing();
        protected internal virtual void RaiseContentChanged();
        protected internal virtual void RaiseRtfTextChanged();
        protected internal virtual void RaiseHtmlTextChanged();
        protected internal virtual void RaiseMhtTextChanged();
        protected internal virtual void RaiseWordMLTextChanged();
        protected internal virtual void RaiseOpenXmlBytesChanged();
        protected internal virtual void RaiseOpenDocumentBytesChanged();
        protected internal virtual void RaiseReadOnlyChanged();
        protected internal virtual void RaiseModifiedChanged();
        protected internal virtual void RaiseUpdateUI();
        protected internal void RaiseSearchComplete(SearchCompleteEventArgs e);
        protected internal void RaiseZoomFactorChanged();
        protected internal virtual void RaiseBeforeImport(BeforeImportEventArgs args);
        protected internal virtual void RaiseBeforeExport(BeforeExportEventArgs args);
        protected internal virtual void RaiseHyperlinkClick(HyperlinkClickEventArgs args);
        protected internal virtual bool RaiseUnhandledException(Exception e);
        protected internal virtual void BeginInitialize();
        protected internal virtual void EndInitializeCommon();
        protected internal virtual void CreateViews();
        protected internal virtual void DisposeCommon();
        protected internal virtual void DisposeViews();
        protected internal virtual void SetActiveView(RichEditView newView);
        protected internal virtual void SetActiveViewCore(RichEditView newView);
        protected internal virtual Rectangle DeactivateView(RichEditView view);
        protected internal virtual void ActivateView(RichEditView view, Rectangle viewBounds);
        protected internal virtual IVisibleTextFilter CreateVisibleTextFilter();
        protected internal virtual SpellCheckerController CreateSpellCheckerController();
        protected internal virtual RichEditMouseHandler CreateMouseHandler();
        protected internal virtual RichEditViewRepository CreateViewRepository();
        protected internal virtual DocumentModel CreateDocumentModel();
        protected internal virtual void InitializeMouseHandlers();
        protected internal virtual void InitializeKeyboardHandlers();
        protected internal virtual void InitializeKeyboardHandlerDefaults(NormalKeyboardHandler keyboardHandler);

        protected internal virtual void InitializeDefaultViewKeyboardHandlers(NormalKeyboardHandler keyboardHandler,
                                                                              IKeyHashProvider provider);

        protected internal virtual void SetNewKeyboardHandler(KeyboardHandler keyboardHandler);
        protected internal virtual void RestoreKeyboardHandler();
        protected internal virtual void SetNewMouseHandler(MouseHandler mouseHandler);
        protected internal virtual void RestoreMouseHandler();
        protected internal virtual void AddServices();
        public T GetService<T>();
        public virtual void CreateNewDocument();
        public virtual void LoadDocument();
        public virtual void LoadDocument(Stream stream, DocumentFormat documentFormat);
        protected internal virtual void LoadDocumentCore(Stream stream, DocumentFormat documentFormat, string sourceUri);
        public virtual void SaveDocumentAs();
        public virtual void SaveDocumentAs(IWin32Window parent);
        public virtual void SaveDocument(Stream stream, DocumentFormat documentFormat);
        protected internal virtual void SaveDocumentCore(Stream stream, DocumentFormat documentFormat, string targetUri);
        protected internal virtual void LoadDocumentCore(IWin32Window parent);
        protected internal virtual bool CanCloseExistingDocument();
        protected internal virtual void OnLastEndUpdateCore();
        protected internal virtual void ApplyChangesCore(DocumentModelChangeActions changeActions);
        protected internal virtual void RaiseDeferredEventsCore(DocumentModelChangeActions changeActions);
        protected internal virtual void SubscribeDocumentModelEvents();
        protected internal virtual void UnsubscribeDocumentModelEvents();
        protected internal virtual void OnBeginDocumentUpdate(object sender, EventArgs e);
        protected internal virtual void OnEndDocumentUpdateCore(object sender, DocumentUpdateCompleteEventArgs e);
        protected internal virtual void OnEmptyDocumentCreated();
        protected internal virtual void OnDocumentLoaded();
        protected internal virtual DevExpress.XtraRichEdit.Model.CharacterProperties GetDefaultCharacterProperties();
        protected internal virtual void ApplyFontAndForeColor();

        protected internal virtual void ApplyFontAndForeColorCore(
            DevExpress.XtraRichEdit.Model.CharacterProperties characterProperties);

        protected internal virtual void OnSelectionChanged(object sender, EventArgs e);
        protected internal virtual void OnInnerSelectionChanged(object sender, EventArgs e);
        protected internal virtual void OnContentChanged(object sender, EventArgs e);
        protected internal virtual void OnContentChangedCore(bool suppressBindingNotifications);
        protected internal virtual void RaiseBindingNotifications();
        protected internal virtual void OnModifiedChanged(object sender, EventArgs e);
        protected internal virtual void OnInnerContentChanged(object sender, EventArgs e);
        protected internal virtual void OnReadOnlyChanged();
        protected internal virtual void OnBeforeExport(object sender, BeforeExportEventArgs e);
        protected internal virtual void OnBeforeImport(object sender, BeforeImportEventArgs e);
        protected internal virtual void OnDocumentCleared(object sender, EventArgs e);
        protected internal virtual void SubscribeActiveViewEvents();
        protected internal virtual void UnsubscribeActiveViewEvents();
        protected internal virtual void OnActiveViewZoomChanging(object sender, EventArgs e);
        protected internal virtual void OnActiveViewZoomChanged(object sender, EventArgs e);
        protected internal virtual void SubscribeOptionsEvents();
        protected internal virtual void UnsubscribeOptionsEvents();
        protected internal virtual void OnOptionsChanged(object sender, BaseOptionChangedEventArgs e);
        protected internal virtual void OnShowHiddenTextOptionsChanged(bool newValue);
        protected internal virtual void OnSpellCheckerChanged();

        protected internal virtual bool OnHyperlinkClick(DevExpress.XtraRichEdit.Model.Field field,
                                                         bool allowForModifiers);

        protected internal virtual bool IsHyperlinkModifierKeysPress();
        protected internal virtual void OnUpdateUI();
        protected internal virtual void OnUpdateUICore();
        protected internal virtual void BeginDocumentRendering();
        protected internal virtual void EndDocumentRendering();
        protected internal virtual void UpdateUIFromBackgroundThread(EmptyDelegate method);
        protected internal virtual void PerformDeferredUIUpdates(DeferredBackgroundThreadUIUpdater deferredUpdater);
        protected internal void InsertNumberingLists();
        protected internal void InsertBulletNumberingList();
        protected internal void InsertSimpleNumberingList();
        protected internal void SetTemplateCode(IListLevel level, int templateCode);
        protected internal void InsertMultilevelNumberingList();
        protected internal void SetDisplayFormatString(IListLevel level, string displayFormatString);
        protected internal void SetFirstLineIndent(IListLevel level, int lineIndent);
        protected internal virtual void UpdateVerticalScrollBar(bool avoidJump);
        public virtual RichEditCommand CreateCommand(RichEditCommandId commandId);
        public DevExpress.XtraRichEdit.API.Native.DocumentPosition GetPositionFromPoint(Point clientPoint);
        public Rectangle GetBoundsFromPosition(DevExpress.XtraRichEdit.API.Native.DocumentPosition pos);
        protected internal virtual bool HandleException(Exception e);
        public void ScrollToCaret();

        public event EventHandler BeforeDispose;
        public event SearchFormShowingEventHandler SearchFormShowing;
        public event PreparePopupMenuEventHandler PreparePopupMenu;
        public event EventHandler ActiveViewChanged;
        public event EventHandler SelectionChanged;
        public event EventHandler DocumentLoaded;
        public event EventHandler EmptyDocumentCreated;
        public event CancelEventHandler DocumentClosing;
        public event EventHandler ContentChanged;
        public event EventHandler RtfTextChanged;
        public event EventHandler HtmlTextChanged;
        public event EventHandler MhtTextChanged;
        public event EventHandler WordMLTextChanged;
        public event EventHandler OpenXmlBytesChanged;
        public event EventHandler OpenDocumentBytesChanged;
        public event EventHandler ReadOnlyChanged;
        public event EventHandler ModifiedChanged;
        public event EventHandler UpdateUI;
        public event EventHandler ZoomChanged;
        public event BeforeImportEventHandler BeforeImport;
        public event BeforeExportEventHandler BeforeExport;
        public event HyperlinkClickEventHandler HyperlinkClick;
        public event RichEditUnhandledExceptionEventHandler UnhandledException;
    }
}
