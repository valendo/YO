/**
 * Composite plugin.
 */
new function () {
	
	//var URL_UPDATERENDERING = "${root}/content/dialogs/functions/editFunctionCall.aspx?type=Composite.Core.Xml.XhtmlDocument,Composite&functionmarkup=${functionmarkup}";
	var URL_UPDATERENDERING = "${root}/content/dialogs/functions/editFunctionCall.aspx?type=Composite.Core.Xml.XhtmlDocument,Composite";
	
	tinymce.create ( "tinymce.plugins.CompositeRenderingPlugin", {
		
		/**
		 * @type {tinymce.Editor}
		 */
		editor : null,
		
		/**
		 * Get info
		 */
		getInfo : function() {
			return {
				longname : "Composite Rendering Plugin",
				author : "Composite A/S",
				authorurl : "http://www.composite.net",
				infourl : null,
				version : tinymce.majorVersion + "." + tinymce.minorVersion
			};
		},
		
		/**
		 * @param {tinymce.Editor} ed
		 * @param {string} url
		 */
		init : function ( ed, url ) {
			
			this.editor = ed;
			
			var self = this;
			ed.onDblClick.add ( function ( editor, e ) {
				if (VisualEditorBinding.isFunctionElement(e.target)) {
					self._img = e.target;
					self.execCommand ( "compositeInsertRendering", true, "update" );
					self._img = null;
				}
			});
		},
			
		/**
		 * @param {string} cmd
		 * @param {boolean} ui
		 * @param {string} value
		 */
		execCommand : function ( cmd, ui, value ) {
			
			var result = false;
			var self = this;
			var editor = this.editor;
			var editorBinding = editor.theme.editorBinding;
			
			if ( cmd == "compositeInsertRendering" ) {	
				if ( value == "update" ) {
					this._updateRendering ();
				} else {
					this._insertRendering ();
				}
				editorBinding.checkForDirty ();
				result = true;
			} 
			return result;
		},
		
		/**
		 * Insert rendering.
		 */
		_insertRendering : function () {
			
			this.editor.theme.enableDialogMode ();
			
			var def = ViewDefinitions [ "Composite.Management.XhtmlDocumentFunctionSelectorDialog" ];
			
			var self = this;
			def.handler = {
				handleDialogResponse : function ( response, result ) {
					if ( response == Dialog.RESPONSE_ACCEPT ) {
					
						var functionName = result.getFirst ();
						var functionInfo = top.XhtmlTransformationsService.GetFunctionInfo ( functionName );
						
						if ( functionInfo.RequireConfiguration ) {
							self._launchUpdateDialog ( functionInfo.FunctionMarkup );
						} else {
							self.editor.theme.disableDialogMode ()
							self._insertImgTag ( functionInfo.FunctionMarkup );
						}
					} else {
						self.editor.theme.disableDialogMode ()
					}
				}
			}
			Dialog.invokeDefinition ( def );
		},
		
		/**
		 * Update rendering.
		 */
		_updateRendering : function () {
			
			var img = null;
			if ( this._img != null ) {
				img = this._img;
			} else {
				img = this.editor.selection.getNode ();
			}
			if ( img.nodeName.toLowerCase () == "img" ) {
				var markup = img.alt;
				this._launchUpdateDialog ( markup );
			}
		},
		
		/**
		 * Launch update dialog.
		 * @param {string} markup
		 */
		_launchUpdateDialog : function ( markup ) {
			
			this.editor.theme.enableDialogMode ();
			
			var self = this;
			var dialogHandler = {
				handleDialogResponse : function ( response, result ) {
				
					self.editor.theme.disableDialogMode ();
					
					if ( response == Dialog.RESPONSE_ACCEPT ) {
						self._insertImgTag ( result );
					}
				}
			}
			
			/*
			URL_UPDATERENDERING = "${root}/content/dialogs/functions/editFunctionCall.aspx?type=Composite.Core.Xml.XhtmlDocument,Composite&functionmarkup=${functionmarkup}";
			var url = URL_UPDATERENDERING.replace ( 
				"${functionmarkup}", 
				markup
			);
			Dialog.invokeModal ( 
				url,
				dialogHandler, 
				null 
			);
			*/
			
			/*
			 * TODO: Implement this instead...
			 */
			var def = ViewDefinitions [ "Composite.Management.PostBackDialog" ];
			def.width = 880; //760;
			def.height = 520;
			def.label = "${string:Composite.Web.FormControl.FunctionCallsDesigner:DialogTitle}";
			def.image = "${icon:parameter_overloaded}";
			def.handler = dialogHandler;
			def.argument = {
				url : URL_UPDATERENDERING,
				list : new List ([{ name: "functionmarkup", value : markup }])
			}
			StageBinding.presentViewDefinition ( def );
		},
		
		/**
		 * Insert image tag from function markup.
		 * @param {string} markup
		 */
		_insertImgTag : function ( markup ) {
			
			if ( markup != "" ) {
				var html = top.XhtmlTransformationsService.GetImageTagForFunctionCall ( markup );
				this.editor.execCommand ( "mceInsertContent", false, html );
			} else {
				this.editor.execCommand ( "mceInsertContent", false, "" );
			}
			
			this.editor.theme.editorBinding.checkForDirty ();
		}
	});

	// Register plugin
	tinymce.PluginManager.add("compositerendering", tinymce.plugins.CompositeRenderingPlugin);
};
