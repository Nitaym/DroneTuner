using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Drone
{
	public static class APMModes
	{
		public enum Quadrotor {
			ROTOR_STABILIZE = 0,
			ROTOR_ACRO = 1,
			ROTOR_ALT_HOLD = 2,
			ROTOR_AUTO = 3,
			ROTOR_GUIDED = 4,
			ROTOR_LOITER = 5,
			ROTOR_RTL = 6,
			ROTOR_CIRCLE = 7,
			ROTOR_LAND = 9,
			ROTOR_TOY = 11,
			ROTOR_SPORT = 13,
			ROTOR_AUTOTUNE = 15,
			ROTOR_POSHOLD = 16,
            ROTOR_BREAK = 17,
			ROTOR_TES = 18
		}

		public enum FixedWing {
			FIXED_WING_MANUAL  = 0,
			FIXED_WING_CIRCLE  = 1,
			FIXED_WING_STABILIZE  = 2,
			FIXED_WING_TRAINING  = 3,
			FIXED_WING_FLY_BY_WIRE_A  = 5,
			FIXED_WING_FLY_BY_WIRE_B  = 6,
			FIXED_WING_AUTO  = 10,
			FIXED_WING_RTL  = 11,
			FIXED_WING_LOITER  = 12,
			FIXED_WING_GUIDED  = 15
		}

		public enum Rover {
			ROVER_MANUAL = 0,
			ROVER_LEARNING = 2,
			ROVER_STEERING = 3,
			ROVER_HOLD = 4,
			ROVER_AUTO = 10,
			ROVER_RTL = 11,
			ROVER_GUIDED = 15,
			ROVER_INITIALIZING = 16
		}

		public static int UNKNOWN = -1;

		public static String ModeToString(APMModes.Quadrotor mode)
		{
			switch (mode)
			{
				case Quadrotor.ROTOR_STABILIZE:
					return "Stabilize";
				case Quadrotor.ROTOR_ACRO:
					return "Acro";
				case Quadrotor.ROTOR_ALT_HOLD:
					return "Alt Hold";
				case Quadrotor.ROTOR_AUTO:
					return "Auto";
				case Quadrotor.ROTOR_GUIDED:
					return "Guided";
				case Quadrotor.ROTOR_LOITER:
					return "Loiter";
				case Quadrotor.ROTOR_RTL:
					return "RTL";
				case Quadrotor.ROTOR_CIRCLE:
					return "Circle";
				case Quadrotor.ROTOR_LAND:
					return "Land";
				case Quadrotor.ROTOR_TOY:
					return "Toy";
				case Quadrotor.ROTOR_SPORT:
					return "Sport";
				case Quadrotor.ROTOR_AUTOTUNE:
					return "Autotune";
				case Quadrotor.ROTOR_POSHOLD:
					return "Pos Hold";
				case Quadrotor.ROTOR_TES:
					return "Third Eye";
			}

			return "Error";
		}
	}
}