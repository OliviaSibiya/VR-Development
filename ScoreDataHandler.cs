using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreData
{
    public class ScoreDataHandler : MonoBehaviour
    {
        public class ScoreData
        {
            private int score;
            public int ScoreSet
            {
                get { return score; }
                set { score = value; }
            }

            private string taskName;

            public string TaskName
            {
                get { return taskName; }
                set { taskName = value; }
            }
            private bool completed;

            public bool Completed
            {
                get { return completed; }
                set { completed = value; }
            }
            private float time;

            public float Time
            {
                get { return time; }
                set { time = value; }
            }

            public ScoreData(string taskName, bool completed, int score, float time)
            {
                this.score = score;
                this.taskName = taskName;
                this.completed = completed;
                this.time = time;
            }
        }
    }
}
