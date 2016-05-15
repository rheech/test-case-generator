﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskModelReader
{
    public enum TASK_OPERATOR
    {
        NONE,
        ENABLE,
        CHOICE,
        PARALLEL
    }

    public enum NODE_TYPE
    {
        NONE,
        GOAL,
        TASK
    }

    class TaskNode
    {
        public string Name;
        public NODE_TYPE Type;
        public TASK_OPERATOR Operator;
        public bool isLeaf;

        public static TASK_OPERATOR ParseOperator(string operatorName)
        {
            TASK_OPERATOR tOperator;

            switch (operatorName.ToLower())
            {
                case "enable":
                    tOperator = TASK_OPERATOR.ENABLE;
                    break;
                case "choice":
                    tOperator = TASK_OPERATOR.CHOICE;
                    break;
                case "parallel":
                    tOperator = TASK_OPERATOR.PARALLEL;
                    break;
                default:
                    tOperator = TASK_OPERATOR.NONE;
                    break;
            }

            return tOperator;
        }

        public static NODE_TYPE ParseNodeType(string typeName)
        {
            NODE_TYPE nType;

            switch (typeName.ToLower())
            {
                case "goal":
                    nType = NODE_TYPE.GOAL;
                    break;
                case "task":
                    nType = NODE_TYPE.TASK;
                    break;
                default:
                    nType = NODE_TYPE.NONE;
                    break;
            }

            return nType;
        }

        public bool hasNextChildNode
        {
            get
            {
                return !(isLeaf && (Operator == TASK_OPERATOR.NONE));
            }
        }
    }
}
