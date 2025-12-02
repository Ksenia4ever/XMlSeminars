<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="html" indent="yes"/>

    <xsl:template match="/">
        <html>
            <head>
                <title>Seminars</title>
                <meta charset="UTF-8"/>
                <style>
                    table {
                        border-collapse: collapse;
                        width: 100%;
                        font-family: Arial, sans-serif;
                    }
                    th, td {
                        border: 1px solid #aaa;
                        padding: 6px 10px;
                        text-align: left;
                    }
                    th {
                        background: #f0f0f0;
                    }
                    h1 {
                        font-family: Arial;
                    }
                    .date {
                        white-space: nowrap;
                    }
                </style>
            </head>
            <body>
                <h1>Seminars</h1>
                <table>
                    <tr>
                        <th>Topc</th>
                        <th>Descrription</th>
                        <th>Cathedra</th>
                        <th>Faculty</th>
                        <th>Date</th>
                        <th>Header</th>
                    </tr>

                    <!-- for all seminars -->
                    <xsl:for-each select="Seminars/Seminar">
                        <tr>
                            <td>
                                <xsl:value-of select="Topic"/>
                            </td>
                            <td>
                                <xsl:value-of select="Description"/>
                            </td>
                            <td>
                                <xsl:value-of select="Cathedra"/>
                            </td>
                            <td>
                                <xsl:value-of select="Faculty/Department"/>
                                <xsl:text> (</xsl:text>
                                <xsl:value-of select="Faculty/Branch"/>
                                <xsl:text>)</xsl:text>
                            </td>
                            <td class="date">
                                <!-- Date part from ISO8601 -->
                                <xsl:value-of select="substring(Date,1,10)"/>
                            </td>
                            <td>
                                <xsl:value-of select="Header/Surname"/>
                                <xsl:text> </xsl:text>
                                <xsl:value-of select="Header/Name"/>
                            </td>
                        </tr>
                    </xsl:for-each>
                </table>
            </body>
        </html>
    </xsl:template>
    
</xsl:stylesheet>
