<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="html" version="4.0" encoding="iso-8859-1" indent="yes"/>
  <xsl:template match="/ArrayOfGroupeControle">
    <html xmlns="http://www.w3.org/1999/xhtml" >
      <head>
        <title>Fiche de contrôle</title>
        <style type="text/css">
          body{font-family: Arial;font-size:10pt}
          td{font-size:10pt}
          h1 {text-align:center;
              font-size:14pt;
              border:solid 2px black;
              background:lightGrey;
              margin:0.5cm 2cm 0.5cm 2cm}
          td.saisieValeur {width:8cm;height:1.5cm}
        </style>
      </head>
      <body>
        <h2>Fiche de contrôle produit</h2>
        <xsl:apply-templates select="GroupeControle"/>
      </body>
    </html>
  </xsl:template>

  <xsl:template match="GroupeControle">
    <h1>
      <xsl:value-of select="@TitreGroupe"/> / <xsl:value-of select="@CodeProduit"/>
    </h1>
    <table align="center"  border="1" cellspacing="0" cellpadding="5" bordercolor="black" style="margin-bottom:1cm">
      <tr>
        <th>N°</th>
        <th>Contrôle</th>
        <th>Valide si</th>
        <th>Valeur</th>
      </tr>
      <xsl:apply-templates select="ListeDefinitionsControles/DefinitionControle"/>
    </table>
  </xsl:template>

  <xsl:template match="DefinitionControle">
    <xsl:if test="Type!='Expression' and Type!='Separator'">
      <tr>
        <td>
          <xsl:value-of select="IdControle"/>
        </td>
        <td>
          <xsl:value-of select="Libelle"/>
        </td>
        <td>
          <xsl:apply-templates select="ListeBaremes/Bareme"/>
          <span style="color:white">_</span>
        </td>
        <td class="saisieValeur">
          <xsl:choose>
            <xsl:when test="Type='RadioButton' or Type='CheckBox'">
              <table width="100%" height="100%">
                <tr>
                  <xsl:call-template name="split">
                    <xsl:with-param name="string" select="ValeursPossibles"/>
                    <xsl:with-param name="type" select="Type"/>
                    <xsl:with-param name="sep" select="';'"/>
                  </xsl:call-template>
                </tr>
              </table>
            </xsl:when>
            <xsl:otherwise>
              <span style="color:white">_</span>
            </xsl:otherwise>
          </xsl:choose>
        </td>
      </tr>
    </xsl:if>
  </xsl:template>

  <xsl:template name="split">
    <xsl:param name="string"/>
    <xsl:param name="type" />
    <xsl:param name="sep" />
    <xsl:if test="string-length($string)>0">
      <xsl:variable name="input">
        <input>
          <xsl:if test="$type='RadioButton'">
            <xsl:attribute name="type">radio</xsl:attribute>
          </xsl:if>
          <xsl:if test="$type='CheckBox'">
            <xsl:attribute name="type">checkbox</xsl:attribute>
          </xsl:if>
        </input>
      </xsl:variable>
      <xsl:choose>
        <xsl:when test="contains($string,$sep)">
          <td>
            <xsl:copy-of select="$input"/>
            <xsl:value-of select="substring-before($string,$sep)"/>
          </td>
          <xsl:call-template name="split">
            <xsl:with-param name="string" select="substring-after($string,$sep)"/>
            <xsl:with-param name="type" select="$type"/>
            <xsl:with-param name="sep" select="$sep"/>
          </xsl:call-template>
        </xsl:when>
        <xsl:otherwise>
          <td>
            <xsl:copy-of select="$input"/>
            <xsl:value-of select="$string"/>
          </td>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:if>
  </xsl:template>

  <xsl:template match="Bareme">
    <xsl:value-of select="Expression"/>
  </xsl:template>
</xsl:stylesheet>