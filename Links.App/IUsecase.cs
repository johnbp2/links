using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Links.Application
{

    public interface IUseCase<TInput, TOutput>
    {



        TOutput Execute(TInput input);

    }

    public interface IUseCaseInput<TInput>
    {
        TInput HtmlAnchors
        {
            get;


        }



    }


    public interface IUseCaseOutput<TOutput>
    {
        TOutput Html
        {
            get;

        }



    }
}
