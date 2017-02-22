namespace ProgramFlow
{
    /// <summary>
    /// Defines methods that demonstrate decision and looping structures.
    /// </summary>
    public static class Flow
    {
        /// <summary>
        /// Returns the inverse value for a boolean.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to invert.</param>
        /// <returns><b>true</b> if <paramref name="value"/> is <b>false</b>; <b>false</b> if <paramref name="value"/> is <b>true</b>.</returns>
        public static bool InvertBoolean(bool value)
        {
            //Return the inverted boolean.
            return !value;
        }

        /// <summary>
        /// Returns the correct <see cref="DriverAction"/> value for each <see cref="LightColor"/> using an if-else statement.
        /// </summary>
        /// <param name="color">The <see cref="LightColor"/> for which to return a <see cref="DriverAction"/>.</param>
        /// <returns>The correct <see cref="DriverAction"/> value.</returns>
        public static DriverAction DriveSafelyIfElse(LightColor color)
        {
            var driverAction = DriverAction.Unknown;

            if (color == LightColor.Green)
            {
                driverAction = DriverAction.ProceedWithCaution;
            }
            else if (color == LightColor.Yellow)
            {
                driverAction = DriverAction.StopIfSafe;
            }
            else if (color == LightColor.Red)
            {
                driverAction = DriverAction.Stop;
            }

            return driverAction;
        }

        /// <summary>
        /// Returns the correct <see cref="DriverAction"/> value for each <see cref="LightColor"/> using a switch statement.
        /// </summary>
        /// <param name="color">The <see cref="LightColor"/> for which to return a <see cref="DriverAction"/>.</param>
        /// <returns>The correct <see cref="DriverAction"/> value.</returns>
        public static DriverAction DriveSafelySwitch(LightColor color)
        {
            var driverAction = DriverAction.Unknown;

            switch (color)
            {
                case LightColor.Green:
                    driverAction = DriverAction.ProceedWithCaution;
                    break;
                case LightColor.Yellow:
                    driverAction = DriverAction.StopIfSafe;
                    break;
                case LightColor.Red:
                    driverAction = DriverAction.Stop;
                    break;
            }

            return driverAction;
        }

        /// <summary>
        /// Returns the sum of the specified numbers using a for loop.
        /// </summary>
        /// <param name="values">The values to aggregate.</param>
        /// <returns>The sum of the numbers.</returns>
        public static long ForSum(int[] values)
        {
            int runningSum = 0;

            for (int i = 0; i < values.Length; i++)
            {
                runningSum += values[i];
            }
            return runningSum;
        }

        /// <summary>
        /// Returns the sum of the specified numbers using a foreach loop.
        /// </summary>
        /// <param name="values">The values to aggregate.</param>
        /// <returns>The sum of the numbers.</returns>
        public static long ForEachSum(int[] values)
        {
            int runningSum = 0;

            foreach (var value in values)
            {
                runningSum += value;
            }
            return runningSum;

        }
    }
}
