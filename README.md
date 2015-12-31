# FingerPrint

  DPFP.Template template = createRegTemplate.Template;
  MemoryStream  mem= new MemoryStream();
  template.Serialize(mem);                              
  byte[] huella1 = mem.ToArray();
