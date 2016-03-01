<%@ Page Language="c#" ContentType="image/jpeg" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.Net" %>

<script language="C#" runat="server">

protected void Page_Load(object sender, EventArgs e)
{
	//Jpeg compression quality
	short nQuality = 45;

	//Shout a picture from my webcam
	CAMSERVERLib.Camera cam = new CAMSERVERLib.CameraClass();

	byte[] picture = (byte[])cam.GrabFrame( nQuality );

	//Add the hour to the jpeg picture
	MemoryStream ms = new MemoryStream( picture );
	Bitmap bmp = new Bitmap( ms );

	Graphics g = Graphics.FromImage( bmp );

	string strDate = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString();
	
	StringFormat drawFormat = new StringFormat();
    drawFormat.Alignment = StringAlignment.Center;

	g.DrawString(	strDate,
					new Font( FontFamily.GenericSansSerif, 12 ),
					new SolidBrush( Color.Black ), 
					new RectangleF( 1,1,320,240 ),
					drawFormat
				);

	g.DrawString(	strDate,
					new Font( FontFamily.GenericSansSerif, 12 ),
					new SolidBrush( Color.White ), 
					new RectangleF( 0,0,320,240 ),
					drawFormat
				);

	//Get codecs
	ImageCodecInfo[] icf = ImageCodecInfo.GetImageEncoders();

	EncoderParameters encps = new EncoderParameters( 1 );
	EncoderParameter encp = new EncoderParameter( System.Drawing.Imaging.Encoder.Quality, (long) nQuality );

	//Set quality
	encps.Param[0] = encp;

	bmp.Save( Response.OutputStream, icf[1], encps );
	
	g.Dispose();
	bmp.Dispose();
}
</script>
