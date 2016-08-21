using DataLayer.Entities.MCDT;
using DataLayer.Entities.MCDTEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces {
    interface ILabExams {

        void saveKft(List<KFT> kftList);

        void saveLft(List<LFT> lftList);

        void saveLymphocyteSubsets(List<LymphocytesSubsets> lymList);

        void savePlateletsCount(List<PlateletsCount> platList);

        void saveRbcIndices(List<RBCIndices> rbcIndicesList);

        void saveRbcs(List<RBCS> rbcsList);

        void saveViralLoad(List<ViralLoad> viralList);

        void saveWbcs(List<WBCS> wbcsList);

    }
}
