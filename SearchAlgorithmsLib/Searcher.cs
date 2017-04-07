﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    public abstract class Searcher<T> : ISearcher<T>
    {
        private int evaluatedNodes;
        public Searcher()
        {
            evaluatedNodes = 0;
        }

        protected void increaseEvaluatedNodes()
        {
            evaluatedNodes++;
        }

        // ISearcher’s methods:
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }
        public abstract Solution<T> search(ISearchable<T> searchable);
    }
}