﻿using System.Collections.Generic;

using Newtonsoft.Json;

namespace Machine.Specifications.Reporting.Model
{
  public class Specification : ISpecificationNode
  {
    readonly Status _status;
    readonly ExceptionResult _exception;
    readonly string _name;
    readonly IDictionary<string, IDictionary<string, string>> _supplements;
    readonly Metadata _metadata = new Metadata();

    public Specification(string name, Result result)
    {
      _status = result.Status;
      _exception = result.Exception;
      _supplements = result.Supplements;
      _name = name;
    }

    public Status Status
    {
      get { return _status; }
    }

    public string Name
    {
      get { return _name; }
    }

    public ExceptionResult Exception
    {
      get { return _exception; }
    }

    public IDictionary<string, IDictionary<string, string>> Supplements
    {
      get { return _supplements; }
    }

    public void Accept(ISpecificationVisitor visitor)
    {
      visitor.Visit(this);
    }

    [JsonIgnore]
    public IEnumerable<ISpecificationNode> Children
    {
      get { yield break; }
    }

    public Metadata Metadata
    {
      get { return _metadata; }
    }
  }
}
