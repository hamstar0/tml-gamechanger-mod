using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace GameChanger {
	class GameChangerItem : GlobalItem {
		private bool IsAltered = false;

		////////////////

		public override bool InstancePerEntity { get { return true; } }

		
		
		////////////////

		public override GlobalItem Clone( Item item, Item item_clone ) {
			var clone = (GameChangerItem)base.Clone( item, item_clone );
			return clone;
		}

		////////////////

		public override bool NeedsSaving( Item item ) {
			return this.IsAltered ? true : base.NeedsSaving( item );
		}

		public override void Load( Item item, TagCompound tag ) {
			if( tag.ContainsKey( "is_altered" ) ) {
				this.IsAltered = tag.GetBool( "is_altered" );
			}
		}

		public override TagCompound Save( Item item ) {
			return new TagCompound {
				{"is_altered", (bool)this.IsAltered},
			};
		}

		////////////////

		public override void NetReceive( Item item, BinaryReader reader ) {
			this.IsAltered = reader.ReadBoolean();
		}

		public override void NetSend( Item item, BinaryWriter writer ) {
			writer.Write( (bool)this.IsAltered );
		}


		////////////////

		public override void Update( Item item, ref float gravity, ref float max_fall_speed ) {
			if( !this.IsAltered ) {
				this.IsAltered = true;

				//TODO
			}
		}
	}
}
