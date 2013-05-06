﻿/**
* Composite image plugin.
*/
new function () {

    var Event = tinymce.dom.Event;

    tinymce.create("tinymce.plugins.CompositeImageResizePlugin", {

        /**
		* Get info
		*/
        getInfo: function () {
            return {
                longname: "Composite Image Resize Plugin",
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

            var editor = ed;
            var selectedElmX, selectedElmY, selectedElm, selectedElmGhost, selectedHandle, startX, startY, startW, startH, ratio, resizeHandles, width, height;

            // Details about each resize handle how to scale etc
            resizeHandles = {
                nw: [0, 0, -1, -1],
                ne: [1, 0, 1, -1],
                se: [1, 1, 1, 1],
                sw: [0, 1, -1, 1]
            };

            function resizeElement(e) {
                var deltaX, deltaY;

                // Calc new width/height
                deltaX = e.screenX - startX;
                deltaY = e.screenY - startY;

                // Calc new size
                width = deltaX * selectedHandle[2] + startW;
                height = deltaY * selectedHandle[3] + startH;

                // Never scale down lower than 5 pixels
                width = width < 5 ? 5 : width;
                height = height < 5 ? 5 : height;

                // Grid 5px
                height = Math.round(height / 5) * 5;

                // Constrain proportions when modifier key is pressed or if the nw, ne, sw, se corners are moved on an image
                if (tinymce.VK.modifierPressed(e) || (selectedElm.nodeName == "IMG" && selectedHandle[2] * selectedHandle[3] !== 0)) {
                    width = Math.round(height / ratio);
                    height = Math.round(width * ratio);
                }

                // Update ghost size
                editor.dom.setStyles(selectedElmGhost, {
                    width: width,
                    height: height
                });

                // Update ghost X position if needed
                if (selectedHandle[2] < 0 && selectedElmGhost.clientWidth <= width) {
                    editor.dom.setStyle(selectedElmGhost, 'left', selectedElmX + (startW - width));
                }

                // Update ghost Y position if needed
                if (selectedHandle[3] < 0 && selectedElmGhost.clientHeight <= height) {
                    editor.dom.setStyle(selectedElmGhost, 'top', selectedElmY + (startH - height));
                }
                showToolTip(e, width, height);
            }

            function endResize() {

                editor.dom.unbind(editor.getDoc(), 'mousemove', resizeElement);
                editor.dom.unbind(editor.getDoc(), 'mouseup', endResize);

                var compositeUrl = new CompositeUrl(selectedElm.src)
                if (compositeUrl.isMedia) {
                    compositeUrl.setParam("mw", width);
                    compositeUrl.setParam("mh", height);
                    selectedElm.onload = function () {
                        // Remove ghost and update resize handle positions
                        editor.dom.remove(selectedElmGhost);
                        showResizeRect(selectedElm);
                        hideToolTip();
                    }
                    selectedElm.src = compositeUrl.toString();


                }
            }

            function showResizeRect(targetElm, targetWidth, targetHeight) {
                var position;

                hideResizeRect();

                // Get position and size of target
                position = editor.dom.getPos(targetElm);
                selectedElmX = position.x;
                selectedElmY = position.y;
                targetWidth = targetWidth == undefined ? targetElm.offsetWidth : targetWidth;
                targetHeight = targetHeight == undefined ? targetElm.offsetHeight : targetHeight;

                // Reset width/height if user selects a new image/table
                if (selectedElm != targetElm) {
                    selectedElm = targetElm;
                    width = height = 0;
                }

                tinymce.each(resizeHandles, function (handle, name) {
                    var handleElm;

                    // Get existing or render resize handle
                    handleElm = editor.dom.get('mceResizeHandle' + name);
                    if (!handleElm) {
                        handleElm = editor.dom.add(editor.getDoc().documentElement, 'div', {
                            id: 'mceResizeHandle' + name,
                            'class': 'mceResizeHandle',
                            style: 'cursor:' + name + '-resize; margin:0; padding:0'
                        });

                        editor.dom.bind(handleElm, 'mousedown', function (e) {
                            e.preventDefault();

                            startX = e.screenX;
                            startY = e.screenY;
                            startW = selectedElm.clientWidth;
                            startH = selectedElm.clientHeight;
                            ratio = startH / startW;
                            selectedHandle = handle;

                            selectedElmGhost = selectedElm.cloneNode(true);
                            editor.dom.addClass(selectedElmGhost, 'mceClonedResizable');
                            editor.dom.setStyles(selectedElmGhost, {
                                left: selectedElmX,
                                top: selectedElmY,
                                margin: 0
                            });

                            editor.getDoc().documentElement.appendChild(selectedElmGhost);

                            editor.dom.bind(editor.getDoc(), 'mousemove', resizeElement);
                            editor.dom.bind(editor.getDoc(), 'mouseup', endResize);


                        });
                    } else {
                        editor.dom.show(handleElm);
                    }

                    // Position element
                    editor.dom.setStyles(handleElm, {
                        left: (targetWidth * handle[0] + selectedElmX) - (handleElm.offsetWidth / 2),
                        top: (targetHeight * handle[1] + selectedElmY) - (handleElm.offsetHeight / 2)
                    });
                });
            }

            function hideToolTip() {
                editor.dom.hide('mceResizeHandleToolTip');
            }


            function showToolTip(e, width, height) {
                handleElm = editor.dom.get('mceResizeHandleToolTip');
                if (!handleElm) {
                    handleElm = editor.dom.add(editor.getDoc().documentElement, 'div', {
                        id: 'mceResizeHandleToolTip',
                        'class': 'mceResizeToolTip'
                    });
                } else {
                    editor.dom.show(handleElm)
                }

                handleElm.innerHTML = '<span>[' + width + 'x' + height + ']</span>';
                editor.dom.setStyles(handleElm, {
                    width: handleElm.firstChild.offsetWidth
                });

                // Get position and size of ghost
                position = editor.dom.getPos(selectedElmGhost);

                // Position element
                editor.dom.setStyles(handleElm, {
                    left: position.x + selectedElmGhost.offsetWidth * selectedHandle[0],
                    top: position.y + selectedElmGhost.offsetHeight * selectedHandle[1] - 14 + 14 * selectedHandle[1]
                });
            }


            function hideResizeRect() {
                if (selectedElm) {
                    selectedElm.removeAttribute('data-mce-selected');
                }

                for (var name in resizeHandles) {
                    editor.dom.hide('mceResizeHandle' + name);
                }
            }

            // Add CSS for resize handles, cloned element and selected
            editor.contentStyles.push(
						'.mceResizeHandle {' +
								'position: absolute;' +
								'border: 1px solid black;' +
								'background: #FFF;' +
								'width: 5px;' +
								'height: 5px;' +
								'z-index: 10000' +
						'}' +
						'.mceResizeToolTip {' +
								'position: absolute;' +
								'border: 1px solid black;' +
								'background: #888;' +
								'height: 14px;' +
								'width: 50px;' +
								'font-size: 10px;' +
								'color: #EEE;' +
								'z-index: 10000' +
						'}' +
						'.mceResizeHandle:hover {' +
								'background: #000' +
						'}' +
						'img.mceClonedResizable, table.mceClonedResizable {' +
								'position: absolute;' +
								'outline: 1px dashed black;' +
								'opacity: .5;' +
								'z-index: 10000' +
						'}'
				);

            function updateResizeRect() {
                var controlElm = editor.dom.getParent(editor.selection.getNode(), 'img');
                if (controlElm) {
                    var compositeUrl = new CompositeUrl(controlElm.src);
                    if (compositeUrl.isMedia) {
                        showResizeRect(controlElm);
                    }
                    else {
                        hideResizeRect();
                    }
                } else {
                    hideResizeRect();
                }
            }

            //IE Resizing

            function resizeImageStart(e) {

                startW = selectedElm.clientWidth;
                startH = selectedElm.clientHeight;

            }

            function resizeImageEnd(e) {

                var compositeUrl = new CompositeUrl(selectedElm.src);

                var width = selectedElm.clientWidth;
                var height = selectedElm.clientHeight;

                // Never scale down lower than 5 pixels
                width = width < 5 ? 5 : width;
                height = height < 5 ? 5 : height;

                var absIncreaseW = width > startW ? width / startW : startW / width;
                var absIncreaseH = height > startH ? height / startH : startH / height;

                if (absIncreaseW >= absIncreaseH) {
                    height = null;
                } else {
                    width = null;
                }

                compositeUrl.setParam("mw", width);
                compositeUrl.setParam("mh", height);
                selectedElm.src = compositeUrl.toString();
                selectedElm.style.removeAttribute("width");
                selectedElm.style.removeAttribute("height");
                selectedElm.removeAttribute("width");
                selectedElm.removeAttribute("height");


            }

            function removeResizeHandler() {

            }

            function setResizeHandler(controlElm) {
                if (CompositeUrl.isMedia(controlElm.src)) {
                    removeResizeHandler();
                    selectedElm = controlElm;
                    selectedElm.onresizestart = resizeImageStart;
                    selectedElm.onresizeend = resizeImageEnd;
                } else {
                    controlElm.onresizestart = Event.cancel;
                }
            }

            function updateResizeHandler() {
                var controlElm = editor.dom.getParent(editor.selection.getNode(), 'img');
                if (controlElm) {
                    setResizeHandler(controlElm)
                } else {
                    removeResizeHandler();
                }
            }

            if (Client.isExplorer) {
                editor.onNodeChange.add(updateResizeHandler);
            } else {
                // Show/hide resize rect when image is selected
                editor.onNodeChange.add(updateResizeRect);
            }

        }

    });

    // Register plugin
    tinymce.PluginManager.add("compositeimageresize", tinymce.plugins.CompositeImageResizePlugin);

};