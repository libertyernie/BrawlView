using BrawlLib.SSBB.ResourceNodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrawlView {
	public partial class ModelForm : Form {
		private bool givenArgs;
		private ResourceNode rootNode;

		public ModelForm() {
			InitializeComponent();
			this.Shown += Form1_Shown;
		}

		public ModelForm(ResourceNode node)
			: this() {
				if (node != null) {
					givenArgs = true;
					rootNode = node;
				}
		}

		public ModelForm(string filename)
			: this() {
				if (filename != null) {
					givenArgs = true;
					rootNode = NodeFactory.FromFile(null, filename);
					if (rootNode == null) {
						MessageBox.Show(this, "Could not read file: " + filename);
					}
				}
		}

		void Form1_Shown(object sender, EventArgs e) {
			if (!givenArgs) {
				var dialog = new OpenFileDialog();
				if (DialogResult.OK != dialog.ShowDialog(this)) {
					return;
				}
				rootNode = NodeFactory.FromFile(null, dialog.FileName);
			}

			this.Text = rootNode.Name;
			if (rootNode is RSTMNode) {
				PropertyGrid grid = new PropertyGrid() {
					Dock = DockStyle.Fill,
					HelpVisible = false,
					SelectedObject = rootNode
				};
				AudioPlaybackPanel ap = new AudioPlaybackPanel() {
					TargetSource = (RSTMNode)rootNode,
					Dock = DockStyle.Bottom
				};
				this.Controls.Clear();
				this.Controls.Add(grid);
				this.Controls.Add(ap);
				this.Controls.Add(menuStrip1);
			} else {
				List<MDL0Node> models = new List<MDL0Node>();
				PopulateModelList(rootNode, models);
				modelPanel1.ClearAll();
				//this.Controls.Add(modelPanel1);
				Vector3? fmin = null, fmax = null;
				foreach (MDL0Node model in models) {
					if (model.Name.Contains("Shd")) continue; // skip
					model.Populate();
					model._renderBones = false;
					model._renderPolygons = true;
					model._renderWireframe = false;
					model._renderVertices = false;
					model._renderBox = false;
					model._renderNormals = false;
					model.ApplyCHR(null, 0);
					model.ApplySRT(null, 0);
					modelPanel1.AddTarget(model);

					Vector3 min, max;
					model.GetBox(out min, out max);
					fmin = Vector3.Min(fmin ?? min, min);
					fmax = Vector3.Max(fmax ?? max, max);
				}
				if (models.Count > 0) {
					fmin = Vector3.Max(fmin.Value, new Vector3(-100f));
					fmax = Vector3.Min(fmax.Value, new Vector3(100f));
					modelPanel1.SetCamWithBox(fmin.Value, fmax.Value);
				} else {
					MessageBox.Show(this, "There are no MDL0 models in this file.");
				}
			}
			this.Update();
		}

		public static void PopulateModelList(ResourceNode node, ICollection<MDL0Node> models) {
			if (node is MDL0Node) {
				models.Add(node as MDL0Node);
			} else if (node.HasChildren) {
				foreach (ResourceNode child in node.Children) {
					PopulateModelList(child, models);
				}
			}
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			new About(null).ShowDialog(this);
		}
	}
}
