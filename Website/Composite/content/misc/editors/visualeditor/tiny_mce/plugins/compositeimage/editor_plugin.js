/**
* Composite image plugin.
*/
new function () {

	var URL_IMAGETREESELECTOR = "${tiny}/plugins/compositeimage/image.aspx";

	tinymce.create("tinymce.plugins.CompositeImagePlugin", {

		/**
		* @type {tinymce.Editor}
		*/
		editor: null,

		/**
		* Hacking a bug where explorer does not recognize  
		* double-click on a newly inserted image...
		*/
		_img: null,

		/**
		* Get info
		*/
		getInfo: function () {
			return {
				longname: "Composite Image Plugin",
				author: "Composite A/S",
				authorurl: "http://www.composite.net",
				infourl: null,
				version: tinymce.majorVersion + "." + tinymce.minorVersion
			};
		},

		/**
		* @param {tinymce.Editor} ed
		* @param {string} url
		*/
		init: function (ed, url) {

			this.editor = ed;

			var self = this;
			ed.onDblClick.add(function (editor, e) {
				if (VisualEditorBinding.isImageElement(e.target)) {
					self._img = e.target;
					self.execCommand("compositeInsertImage", true, "update");
					self._img = null;
				}
			});
		},

		/**
		* @param {string} cmd
		* @param {boolean} ui
		* @param {string} value
		*/
		execCommand: function (cmd, ui, value) {

			var result = false;
			var self = this;
			var editor = this.editor;
			var editorBinding = editor.theme.editorBinding;

			if (cmd == "compositeInsertImage") {

				var img = null;
				if (this._img != null) {
					img = this._img;
				} else {
					img = self.editor.selection.getNode();
				}
				if (img.nodeName.toLowerCase() != "img") {
					//Fix p->img
					var imgs = img.getElementsByTagName("img");
					if (imgs.length > 0) {
						img = imgs[0];
					}
					else {
						img = null;
					}
				}

				this.editor.theme.enableDialogMode();

				var self = this;
				var handler = {
					handleDialogResponse: function (response, result) {

						self.editor.theme.disableDialogMode();


						if (response == Dialog.RESPONSE_ACCEPT) {

							var src = result.get("src");

							if (src && src.indexOf("~") == 0) {
								src = "../../../../.." + src.substring(1);
							}

							var mediaUrl = new CompositeUrl(src);

							if (mediaUrl.isMedia) {
								var maxwidth = 0;
								var maxheight = 0;
								if (result.has("maxwidth"))
									maxwidth = parseInt(result.get("maxwidth"));
								if (result.has("maxheight"))
									maxheight = parseInt(result.get("maxheight"));
								if(maxwidth > 0)
									mediaUrl.setParam("mw", maxwidth);
								if(maxheight > 0)
									mediaUrl.setParam("mh", maxheight);

								
								src = mediaUrl.toString();
							}

							switch (value) {

								case "insert":

									var html = '<img';
									html += makeAttrib('id', result.get("id"));
									html += makeAttrib('class', result.get("classname"));
									html += makeAttrib('src', src);
									html += makeAttrib('alt', result.get("alt"));
									html += makeAttrib('title', result.get("title"));
									html += '/>';

									var inst = tinyMCE.selectedInstance;
									inst.execCommand("mceInsertContent", false, html);
									break;

								case "update":

									if (src != null) {
										img.src = src;
									} else {
										img.src = "";
										img.removeAttribute("src");
									}
									if (result.get("alt") != null) {
										img.alt = result.get("alt");
									} else {
										img.alt = "";
									}
									if (result.get("title") != null) {
										img.title = result.get("title");
									} else {
										img.title = "";
										img.removeAttribute("title");
									}
									if (result.get("id") != null) {
										img.id = result.get("id");
									} else {
										img.id = "";
										img.removeAttribute("id");
									}
									if (result.get("classname") != null) {
										img.className = result.get("classname");
										img.setAttribute("class", result.get("classname"));
									} else {
										img.className = "";
										img.removeAttribute("class");
									}
									//Remove tiny_mce_attribute
									img.removeAttribute("data-mce-src");
									break;
							}

							editorBinding.checkForDirty();
						}
					}
				};

				var arg = {
					tinyAction: value,
					tinyWindow: window,
					tinyElement: img,
					tinyEngine: tinymce,
					tinyInstance: this.editor,
					tinyTheme: this.editor.theme,
					editorBinding: this.editor.theme.editorBinding
				}

				Dialog.invokeModal(URL_IMAGETREESELECTOR, handler, arg);
				result = true;
			}

			return result;
		}
	});

	// Register plugin
	tinymce.PluginManager.add("compositeimage", tinymce.plugins.CompositeImagePlugin);
};